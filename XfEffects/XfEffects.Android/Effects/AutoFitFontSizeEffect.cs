using Android.Runtime;
using Android.Util;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XfEffects.Effects;

//[assembly: ResolutionGroupName("XfEffects")]
[assembly: ExportEffect(typeof(XfEffects.Droid.Effects.AutoFitFontSizeEffect), nameof(XfEffects.Effects.AutoFitFontSizeEffect))]

namespace XfEffects.Droid.Effects
{
    [Preserve(AllMembers = true)]
    public class AutoFitFontSizeEffect : PlatformEffect
    {
        #region Protected Methods

        protected override void OnAttached()
        {
            if (this.Control is TextView textView)
            {
                if (AutoFitFontSizeEffectParameters.GetMinFontSize(this.Element) == NamedSize.Default &&
                    AutoFitFontSizeEffectParameters.GetMaxFontSize(this.Element) == NamedSize.Default)
                    return;

                var min = (int)AutoFitFontSizeEffectParameters.MinFontSizeNumeric(this.Element);
                var max = (int)AutoFitFontSizeEffectParameters.MaxFontSizeNumeric(this.Element);

                if (max <= min)
                    return;

                textView.SetAutoSizeTextTypeUniformWithConfiguration(min, max, 1, (int)ComplexUnitType.Sp);
            }
        }

        protected override void OnDetached()
        {
        }

        #endregion Protected Methods
    }
}