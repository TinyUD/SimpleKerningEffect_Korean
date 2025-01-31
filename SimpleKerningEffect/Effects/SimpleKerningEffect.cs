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

        [Display(GroupName = "그리기", Name = "Z", Description = "그리기 위치(깊이)")]
        [AnimationSlider("F1", "px", -500, 500)]
        public Animation Z { get; } = new Animation(0, -99999, 99999);

        [Display(GroupName = "그리기", Name = "불투명도", Description = "불투명도")]
        [AnimationSlider("F1", "%", 0, 100)]
        public Animation Opacity { get; } = new Animation(100, 0, 100);

        [Display(GroupName = "그리기", Name = "좌우 반전", Description = "좌우 반전")]
        [ToggleSlider]
        public bool Invert { get => invert; set => Set(ref invert, value); }
        bool invert = false;

        [Display(GroupName = "확대율", Name = "전체", Description = "전체 확대율")]
        [AnimationSlider("F1", "%", 0, 500)]
        public Animation Zoom { get; } = new Animation(100, 0, 5000);

        [Display(GroupName = "확대율", Name = "가로 방향", Description = "가로 방향 확대율")]
        [AnimationSlider("F1", "%", 0, 500)]
        public Animation ZoomX { get; } = new Animation(100, 0, 5000);

        [Display(GroupName = "확대율", Name = "세로 방향", Description = "세로 방향 확대율")]
        [AnimationSlider("F1", "%", 0, 500)]
        public Animation ZoomY { get; } = new Animation(100, 0, 5000);

        [Display(GroupName = "회전 각도", Name = "X축", Description = "가로 방향, X축에 대한 회전 각도")]
        [AnimationSlider("F1", "°", -360, 360)]
        public Animation RotationX { get; } = new Animation(0, -36000, 36000);

        [Display(GroupName = "회전 각도", Name = "Y축", Description = "세로 방향, Y축에 대한 회전 각도")]
        [AnimationSlider("F1", "°", -360, 360)]
        public Animation RotationY { get; } = new Animation(0, -36000, 36000);

        [Display(GroupName = "회전 각도", Name = "Z축", Description = "평면 방향, Z축에 대한 회전 각도")]
        [AnimationSlider("F1", "°", -360, 360)]
        public Animation RotationZ { get; } = new Animation(0, -36000, 36000);

        public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            return [];
        }

        public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
        {
            return new SimpleKerningEffectProcessor(this);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables() => [X, Y, Z, Opacity, Zoom, ZoomX, ZoomY, RotationX, RotationY, RotationZ];
    }
}