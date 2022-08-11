using UIKit;

namespace TestAppCC.iOS.Effects
{
    [Foundation.Preserve(AllMembers = true)]
    class TouchEventsGestureRecognizer : UIGestureRecognizer
    {
        readonly TouchEvents _events;

        public TouchEventsGestureRecognizer(TouchEvents events) => _events = events;

        public override void TouchesBegan(Foundation.NSSet touches, UIEvent evt)
        {
            _events.OnTouchBegin();

            base.TouchesBegan(touches, evt);
        }

        public override void TouchesMoved(Foundation.NSSet touches, UIEvent evt)
        {
            _events.OnTouchMove();

            base.TouchesMoved(touches, evt);
        }

        public override void TouchesEnded(Foundation.NSSet touches, UIEvent evt)
        {
            _events.OnTouchEnd();

            base.TouchesEnded(touches, evt);
        }

        public override void TouchesCancelled(Foundation.NSSet touches, UIEvent evt)
        {
            _events.OnTouchCancel();

            base.TouchesCancelled(touches, evt);
        }
    }
}
