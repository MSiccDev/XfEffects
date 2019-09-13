using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("XfEffects")]
[assembly: ExportEffect(typeof(XfEffects.iOS.Effects.ImageButtonTintEffect), nameof(XfEffects.Effects.ImageButtonTintEffect))]

namespace XfEffects.iOS.Effects
{
    public class ImageButtonTintEffect : PlatformEffect
    {
        protected override void OnAttached() => UpdateTint();

        protected override void OnDetached()
        {

        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == XfEffects.Effects.ImageButtonTintEffectExtensions.TintColorProperty.PropertyName)
            {
                UpdateTint();
            }
        }


        private void UpdateTint()
        {
            try
            {
                if (this.Control is UIButton imagebutton)
                {
                    if (imagebutton.ImageView?.Image != null)
                    {
                        var templatedImg = imagebutton.CurrentImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);

                        imagebutton.SetImage(null, UIControlState.Normal);

                        imagebutton.ImageView.TintColor = XfEffects.Effects.ImageButtonTintEffectExtensions.GetTintColor(this.Element).ToUIColor();
                        imagebutton.TintColor = XfEffects.Effects.ImageButtonTintEffectExtensions.GetTintColor(this.Element).ToUIColor();

                        imagebutton.SetImage(templatedImg, UIControlState.Normal);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred when setting the {typeof(ImageButtonTintEffect)} effect: {ex.Message}\n{ex.StackTrace}");
            }
        }
    }

}