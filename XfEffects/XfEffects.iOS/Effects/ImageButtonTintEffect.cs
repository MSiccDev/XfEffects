using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(XfEffects.iOS.Effects.ImageButtonTintEffect), nameof(XfEffects.Effects.ImageButtonTintEffect))]

namespace XfEffects.iOS.Effects
{
    public class ImageButtonTintEffect : PlatformEffect
    {
        #region Protected Methods

        protected override void OnAttached() => UpdateTintColor();

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == XfEffects.Effects.ImageButtonTintEffectParameters.TintColorProperty.PropertyName)
                UpdateTintColor();

            if (args.PropertyName == ImageButton.SourceProperty.PropertyName)
                UpdateTintColor();
        }

        #endregion Protected Methods

        #region Private Methods

        private void UpdateTintColor()
        {
            try
            {
                if (this.Control is UIButton imagebutton)
                {
                    //as of XF 4.4, this check breaks the tinting process
                    //deactivated it for the time being
                    //if (imagebutton.ImageView?.Image != null)
                    //{
                    var templatedImg = imagebutton.CurrentImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);

                    //clear the image on the button
                    imagebutton.SetImage(null, UIControlState.Normal);

                    imagebutton.ImageView.TintColor = XfEffects.Effects.ImageButtonTintEffectParameters.GetTintColor(this.Element).ToUIColor();
                    imagebutton.TintColor = XfEffects.Effects.ImageButtonTintEffectParameters.GetTintColor(this.Element).ToUIColor();

                    imagebutton.SetImage(templatedImg, UIControlState.Normal);
                    //}
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred when setting the {typeof(ImageButtonTintEffect)} effect: {ex.Message}\n{ex.StackTrace}");
            }
        }

        #endregion Private Methods
    }
}