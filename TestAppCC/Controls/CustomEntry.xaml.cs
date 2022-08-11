using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestAppCC.Controls
{
    public partial class CustomEntry : Frame
    {
        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword),
            typeof(bool), typeof(CustomEntry), default(bool), propertyChanged: OnIsPasswordPropertyChanged);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor),
            typeof(Color), typeof(CustomEntry), Color.Black, propertyChanged: OnTextColorPropertyChanged);

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder),
            typeof(string), typeof(CustomEntry), string.Empty, propertyChanged: OnPlaceholderPropertyChanged);

        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(CustomEntry), Color.Black,
                propertyChanged: OnPlaceholderColorPropertyChanged);

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize),
            typeof(double), typeof(CustomEntry), 12.0, propertyChanged: OnFontSizePropertyChanged);

        public static readonly BindableProperty TextAlignmentProperty = BindableProperty.Create(nameof(TextAlignment),
            typeof(TextAlignment), typeof(CustomEntry), TextAlignment.Start,
            propertyChanged: OnTextAlignmentPropertyChanged);

        public static readonly BindableProperty GlyphSizeProperty =
            BindableProperty.Create(nameof(GlyphSize), typeof(double), typeof(CustomEntry));

        public static readonly BindableProperty GlyphMarginProperty =
            BindableProperty.Create(nameof(GlyphMargin), typeof(Thickness), typeof(CustomEntry));

        public static readonly BindableProperty GlyphProperty =
            BindableProperty.Create(nameof(Glyph), typeof(string), typeof(CustomEntry));

        public static readonly BindableProperty GlyphColorProperty =
            BindableProperty.Create(nameof(GlyphColor), typeof(Color), typeof(CustomEntry));

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string),
            typeof(CustomEntry), string.Empty, BindingMode.TwoWay);

        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard),
            typeof(Keyboard), typeof(CustomEntry), Keyboard.Default, BindingMode.OneTime,
            propertyChanged: OnKeyboardPropertyChanged);

        public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(nameof(Keyboard),
            typeof(ReturnType), typeof(CustomEntry), ReturnType.Default, BindingMode.OneTime,
            propertyChanged: ReturnTypePropertyChanged);

        public static readonly BindableProperty UnfocusedCommandProperty =
            BindableProperty.Create(nameof(UnfocusedCommand), typeof(ICommand), typeof(CustomEntry));

        public static readonly BindableProperty FocusedCommandProperty =
            BindableProperty.Create(nameof(FocusedCommand), typeof(ICommand), typeof(CustomEntry));

        public static readonly BindableProperty CompletedCommandProperty =
            BindableProperty.Create(nameof(CompletedCommand), typeof(ICommand), typeof(CustomEntry));

        public static readonly BindableProperty ShouldFocusProperty = BindableProperty.Create(nameof(ShouldFocus),
            typeof(bool), typeof(CustomEntry), default(bool), propertyChanged: ShouldFocusPropertyChanged);

        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public Color PlaceholderColor
        {
            get => (Color)GetValue(PlaceholderColorProperty);
            set => SetValue(PlaceholderColorProperty, value);
        }

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public TextAlignment TextAlignment
        {
            get => (TextAlignment)GetValue(TextAlignmentProperty);
            set => SetValue(TextAlignmentProperty, value);
        }

        public double GlyphSize
        {
            get => (double)GetValue(GlyphSizeProperty);
            set => SetValue(GlyphSizeProperty, value);
        }

        public Thickness GlyphMargin
        {
            get => (Thickness)GetValue(GlyphMarginProperty);
            set => SetValue(GlyphMarginProperty, value);
        }

        public string Glyph
        {
            get => (string)GetValue(GlyphProperty);
            set => SetValue(GlyphProperty, value);
        }

        public Color GlyphColor
        {
            get => (Color)GetValue(GlyphColorProperty);
            set => SetValue(GlyphColorProperty, value);
        }

        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }

        public ReturnType ReturnType
        {
            get => (ReturnType)GetValue(ReturnTypeProperty);
            set => SetValue(ReturnTypeProperty, value);
        }

        public ICommand UnfocusedCommand
        {
            get => (ICommand)GetValue(UnfocusedCommandProperty);
            set => SetValue(UnfocusedCommandProperty, value);
        }

        public ICommand FocusedCommand
        {
            get => (ICommand)GetValue(FocusedCommandProperty);
            set => SetValue(FocusedCommandProperty, value);
        }

        public ICommand CompletedCommand
        {
            get => (ICommand)GetValue(CompletedCommandProperty);
            set => SetValue(CompletedCommandProperty, value);
        }

        public bool ShouldFocus
        {
            get => (bool)GetValue(ShouldFocusProperty);
            set => SetValue(ShouldFocusProperty, value);
        }

        public CustomEntry()
        {
            InitializeComponent();
            BorderColor = Color.Transparent;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(IsEnabled))
                Entry.IsEnabled = IsEnabled;

            if (propertyName == nameof(Style))
            {
                if (Style != null && Entry != null)
                {
                    if (Entry != null)
                    {
                        if (Style.Setters.Any(x => x.Property.PropertyName == nameof(Entry.PlaceholderColor)))
                        {
                            Entry.PlaceholderColor = (Color)Style.Setters.FirstOrDefault(x => x.Property.PropertyName == nameof(Entry.PlaceholderColor)).Value;
                        }

                        if (Style.Setters.Any(x => x.Property.PropertyName == nameof(Entry.TextColor)))
                        {
                            Entry.TextColor = (Color)Style.Setters.FirstOrDefault(x => x.Property.PropertyName == nameof(Entry.TextColor)).Value;
                        }

                        if (Style.Setters.Any(x => x.Property.PropertyName == nameof(Entry.FontSize)))
                        {
                            Entry.FontSize = (double)Style.Setters.FirstOrDefault(x => x.Property.PropertyName == nameof(Entry.FontSize)).Value;
                        }

                        if (Style.Setters.Any(x => x.Property.PropertyName == nameof(Entry.FontFamily)))
                        {
                            Entry.FontFamily = (string)Style.Setters.FirstOrDefault(x => x.Property.PropertyName == nameof(Entry.FontFamily)).Value;
                        }
                    }

                    if (Style.Setters.Any(x => x.Property.PropertyName == nameof(CornerRadius)))
                    {
                        CornerRadius = (float)Style.Setters.FirstOrDefault(x => x.Property.PropertyName == nameof(CornerRadius)).Value;
                    }

                    if (Style.Setters.Any(x => x.Property.PropertyName == nameof(Padding)))
                    {
                        Padding = (Thickness)Style.Setters.FirstOrDefault(x => x.Property.PropertyName == nameof(Padding)).Value;
                    }

                    if (Style.Setters.Any(x => x.Property.PropertyName == nameof(BorderColor)))
                    {
                        BorderColor = (Color)Style.Setters.FirstOrDefault(x => x.Property.PropertyName == nameof(BorderColor)).Value;
                    }

                    if (Style.Setters.Any(x => x.Property.PropertyName == nameof(HeightRequest)))
                    {
                        HeightRequest = (double)Style.Setters.FirstOrDefault(x => x.Property.PropertyName == nameof(HeightRequest)).Value;
                    }

                    if (Style.Setters.Any(x => x.Property.PropertyName == nameof(BackgroundColor)))
                    {
                        BackgroundColor = (Color)Style.Setters.FirstOrDefault(x => x.Property.PropertyName == nameof(BackgroundColor)).Value;
                    }
                }
            }
        }

        static void OnIsPasswordPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (((CustomEntry)bindable).Entry == null)
                return;
            ((CustomEntry)bindable).Entry.IsPassword = (bool)newValue;
        }

        static void OnKeyboardPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (((CustomEntry)bindable).Entry == null)
                return;
            ((CustomEntry)bindable).Entry.Keyboard = (Keyboard)newValue;
        }

        static void OnTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (((CustomEntry)bindable).Entry == null)
                return;
            ((CustomEntry)bindable).Entry.TextColor = (Color)newValue;
        }

        static void OnPlaceholderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (((CustomEntry)bindable).Entry == null)
                return;
            ((CustomEntry)bindable).Entry.Placeholder = (string)newValue;
        }

        static void OnPlaceholderColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (((CustomEntry)bindable).Entry == null)
                return;
            ((CustomEntry)bindable).Entry.PlaceholderColor = (Color)newValue;
        }

        static void OnFontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (((CustomEntry)bindable).Entry == null)
                return;
            ((CustomEntry)bindable).Entry.FontSize = (double)newValue;
        }

        static void OnTextAlignmentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (((CustomEntry)bindable).Entry == null)
                return;
            ((CustomEntry)bindable).Entry.HorizontalTextAlignment = (TextAlignment)newValue;
        }

        static void ReturnTypePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CustomEntry entry) || !(newValue is ReturnType returnType))
                return;

            entry.Entry.ReturnType = returnType;
        }

        static void ShouldFocusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CustomEntry entry) || !(newValue is bool shouldFocus))
                return;

            if (!shouldFocus)
                return;

            entry.Entry.Focus();
        }
    }
}

