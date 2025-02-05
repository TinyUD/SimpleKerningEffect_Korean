using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Effects;

namespace SimpleKerningEffect.Effects
{
    [VideoEffect("간단 커닝", ["텍스트"], ["kerning", "문자", "텍스트", "text", "플러그인", "plugin"], isAviUtlSupported: false, isEffectItemSupported: false)]
    internal class SimpleKerningEffect : VideoEffectBase
    {
        public override string Label => "간단 커닝";

        [Display(GroupName = "간단 커닝\r\n대상 문자 위치를 숫자로 지정합니다\r\n쉼표(,)로 여러 개 지정, 하이픈(-)으로 범위 지정", Name = "문자 위치", Description = "몇 번째 문자를 대상으로 할지 설정합니다\r\n예: 1,3,5-10")]
        [TextEditor(AcceptsReturn = true)]
        public string Index { get => index; set => Set(ref index, value); }
        string index = string.Empty;

        [Display(GroupName = "그리기", Name = "X", Description = "그리기 위치(가로 방향)")]
        [AnimationSlider("F1", "px", -500, 500)]
        public Animation X { get; } = new Animation(0, -99999, 99999);

        [Display(GroupName = "그리기", Name = "Y", Description = "그리기 위치(세로 방향)")]
        [AnimationSlider("F1", "px", -500, 500)]
        public Animation Y { get; } = new Animation(0, -99999, 99999);

        [Display(GroupName = "그리기", Name = "Z", Description = "그리기 위치(깊이 방향)")]
        [AnimationSlider("F1", "px", -500, 500)]
        public Animation Z { get; } = new Animation(0, -99999, 99999);

        [Display(GroupName = "그리기", Name = "불투명도", Description = "불투명도")]
        [AnimationSlider("F1", "%", 0, 100)]
        public Animation Opacity { get; } = new Animation(100, 0, 100);

        [Display(GroupName = "그리기", Name = "확대/축소", Description = "확대/축소")]
        [AnimationSlider("F1", "%", 0, 400)]
        public Animation Zoom { get; } = new Animation(100, 0, 5000);

        [Display(GroupName = "그리기", Name = "회전 각도", Description = "회전 각도(오른쪽 방향)")]
        [AnimationSlider("F1", "°", -360, 360)]
        public Animation Rotation { get; } = new Animation(0, -36000, 36000);

        [Display(GroupName = "그리기", Name = "좌우 반전", Description = "좌우 반전")]
        [ToggleSlider]
        public bool Invert { get => invert; set => Set(ref invert, value); }
        bool invert = false;

        [Display(GroupName = "간단 커닝 내 효과", Name = "", Description = "대상 문자에 적용할 비디오 효과")]
        [VideoEffectSelector(PropertyEditorSize = PropertyEditorSize.FullWidth)]
        public ImmutableList<IVideoEffect> Effects { get => effects; set => Set(ref effects, value); }
        ImmutableList<IVideoEffect> effects = [];

        public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            return [];
        }

        public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
        {
            return new SimpleKerningEffectProcessor(this, devices);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables() => [X, Y, Z, Opacity, Zoom, Rotation, .. Effects];
    }
}