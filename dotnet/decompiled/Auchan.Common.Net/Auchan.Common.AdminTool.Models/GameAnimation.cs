namespace Auchan.Common.AdminTool.Models;

public class GameAnimation
{
	public string AnimationUrl { get; }

	public GameAnimationPosition Position { get; }

	public int Priority { get; }

	public bool CloseButtonEnabled { get; }

	public GameAnimationClosePosition ClosePosition { get; }

	public int CloseButtonHorizontalOffset { get; }

	public int CloseButtonVerticalOffset { get; }

	public string CloseButtonImageUrl { get; }

	public string CloseAnimationUrl { get; }

	public GameAnimation(string animationUrl, GameAnimationPosition position, int priority, bool closeButtonEnabled, GameAnimationClosePosition closePosition, int closeButtonHorizontalOffset, int closeButtonVerticalOffset, string closeButtonImageUrl, string closeAnimationUrl)
	{
		AnimationUrl = animationUrl;
		Position = position;
		Priority = priority;
		CloseButtonEnabled = closeButtonEnabled;
		ClosePosition = closePosition;
		CloseButtonHorizontalOffset = closeButtonHorizontalOffset;
		CloseButtonVerticalOffset = closeButtonVerticalOffset;
		CloseButtonImageUrl = closeButtonImageUrl;
		CloseAnimationUrl = closeAnimationUrl;
	}
}
