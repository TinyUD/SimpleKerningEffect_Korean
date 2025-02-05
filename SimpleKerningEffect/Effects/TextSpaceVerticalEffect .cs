using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Effects;

namespace SimpleKerningEffect.Effects
{
    [VideoEffect("글자 간격 조정(세로)", ["tetra_te"], ["kerning", "글자", "tetra_te", "텍스트", "text", "플러그인", "plugin"], isAviUtlSupported: false, isEffectItemSupported: false)]
    internal class TextSpaceVerticalEffect : VideoEffectBase
    {
        public override string Label => $"글자 간격 조정 (세로) {Space.GetValue(0, 1, 30):F1}";

        [Display(GroupName = "글자 간격 조정(세로쓰기)", Name = "시작", Description = "조정할 글자의 시작 위치")]
        [TextBoxSlider("F0", "", 1, 5)]
        [DefaultValue(1d)]
        [Range(1, 99999)]
        public double Start { get => start; set => Set(ref start, value); }
        double start = 1;

        [Display(GroupName = "글자 간격 조정(세로쓰기)", Name = "종료", Description = "조정할 글자의 종료 위치")]
        [TextBoxSlider("F0", "", 1, 5)]
        [DefaultValue(1d)]
        [Range(1, 99999)]
        public double End { get => end; set => Set(ref end, value); }
        double end = 1;

        [Display(GroupName = "글자 간격 조정(세로쓰기)", Name = "글자 간격", Description = "글자 간격")]
        [AnimationSlider("F1", "", -50, 50)]
        public Animation Space { get; } = new Animation(0, -99999, 99999);

        [Display(GroupName = "글자 간격 조정(세로쓰기)", Name = "전체 조정", Description = "범위 밖의 글자 위치를 조정합니다.")]
        [ToggleSlider]
        public bool Adjust { get => adjust; set => Set(ref adjust, value); }
        bool adjust = true;

        public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            return [];
        }

        public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
        {
            return new TextSpaceVerticalEffectProcessor(this);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables() => [Space];
    }
}