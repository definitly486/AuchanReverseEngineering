using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VisibilitySwitch;

public abstract class VisibilitySwitchBase<TState, TView> : IReadOnlyDictionary<TState, TView[]>, IEnumerable<KeyValuePair<TState, TView[]>>, IEnumerable, IReadOnlyCollection<KeyValuePair<TState, TView[]>>
{
	private readonly Dictionary<TState, TView[]> _stateDictionary = new Dictionary<TState, TView[]>();

	private TState _currentState;

	public TState State
	{
		get
		{
			return _currentState;
		}
		set
		{
			_currentState = value;
			SwitchState(value);
		}
	}

	public TView[] this[TState key] => _stateDictionary[key];

	public IEnumerable<TState> Keys => _stateDictionary.Keys;

	public IEnumerable<TView[]> Values => _stateDictionary.Values;

	public int Count => _stateDictionary.Count;

	protected VisibilitySwitchBase(TState initialState = default(TState))
	{
		_currentState = initialState;
	}

	public virtual void Add(TState state, params TView[] views)
	{
		if (_stateDictionary.TryGetValue(state, out var value))
		{
			_stateDictionary[state] = value.Concat(views).ToArray();
		}
		else
		{
			_stateDictionary[state] = views;
		}
		SetState(State, state, views);
	}

	private void SetState(TState targetState, TState state, TView[] views)
	{
		bool visibility = EqualityComparer<TState>.Default.Equals(state, targetState);
		foreach (TView view in views)
		{
			SetVisibility(view, visibility);
		}
	}

	protected abstract void SetVisibility(TView view, bool visibility);

	public void SwitchState(TState newState)
	{
		using IEnumerator<KeyValuePair<TState, TView[]>> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			var (state, views) = (KeyValuePair<TState, TView[]>)(ref enumerator.Current);
			SetState(newState, state, views);
		}
	}

	public bool ContainsKey(TState key)
	{
		return _stateDictionary.ContainsKey(key);
	}

	public IEnumerator<KeyValuePair<TState, TView[]>> GetEnumerator()
	{
		return _stateDictionary.GetEnumerator();
	}

	public bool TryGetValue(TState key, out TView[] value)
	{
		return _stateDictionary.TryGetValue(key, out value);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _stateDictionary.GetEnumerator();
	}
}
