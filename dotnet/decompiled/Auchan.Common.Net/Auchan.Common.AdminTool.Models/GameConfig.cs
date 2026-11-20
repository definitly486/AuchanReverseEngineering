using System;
using System.Collections.Generic;

namespace Auchan.Common.AdminTool.Models;

public class GameConfig
{
	public int Id { get; }

	public string Name { get; }

	public bool GameEnabled { get; }

	public DateTime BeginsOn { get; }

	public DateTime EndsOn { get; }

	public string Url { get; }

	public List<GameAnimation> Animations { get; }

	public string ButtonText { get; }

	public string PopupText { get; }

	public GameConfig(int id, string name, bool gameEnabled, DateTime beginsOn, DateTime endsOn, string url, List<GameAnimation> animations, string buttonText, string popupText)
	{
		Id = id;
		Name = name;
		GameEnabled = gameEnabled;
		BeginsOn = beginsOn;
		EndsOn = endsOn;
		Url = url;
		Animations = animations;
		ButtonText = buttonText;
		PopupText = popupText;
	}
}
