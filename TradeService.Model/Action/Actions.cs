using System;
using System.Collections;
using System.Collections.Generic;

namespace TradeService.Model.Action
{
	/// <summary>
	/// Represent activity concentration point for all actions available with entities
	/// </summary>
	public class Actions
	{
		private static Actions _instance;
		private static readonly object SyncRoot = new Object();

		private Actions()
		{
			ActionHistory = new Stack<ActionBase>();
			ActionUndoHistory = new Stack<ActionBase>();
		}

		/// <summary>
		/// Only one instance of actions available for using
		/// </summary>
		public static Actions Instance
		{
			get
			{
				if (_instance == null)
					lock (SyncRoot)
						if (_instance == null)
							_instance = new Actions();
				return _instance;
			}
		}

		protected Stack<ActionBase> ActionHistory { get; }
		protected Stack<ActionBase> ActionUndoHistory { get; }

		/// <summary>
		/// Run a specified action
		/// </summary>
		/// <param name="action">Action for run</param>
		public void RunAction(ActionBase action)
		{
			action.Apply();
			ActionHistory.Push(action);
			ActionUndoHistory.Clear();
		}

		/// <summary>
		/// Indicates ability to undone last action
		/// </summary>
		public bool IsCanUndo => ActionHistory.Count > 0;

		/// <summary>
		/// Indicates ability to redo last action
		/// </summary>
		public bool IsCanRedo => ActionUndoHistory.Count > 0;

		/// <summary>
		/// Undone last action
		/// </summary>
		public void Undo()
		{
			if (!IsCanUndo) return;
			var action = ActionHistory.Pop();
			action.Regain();
			ActionUndoHistory.Push(action);
		}

		/// <summary>
		/// Redo last action
		/// </summary>
		public void Redo()
		{
			if (!IsCanRedo) return;
			var action = ActionUndoHistory.Pop();
			action.Apply();
			ActionHistory.Push(action);
		}
	}
}