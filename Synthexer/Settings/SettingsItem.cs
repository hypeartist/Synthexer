using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Formatting;

namespace Synthexer.Settings
{
	public sealed class SettingsItem
	{
		public event SettingsChangedEventHandler OptionsChanged;

		private static readonly Dictionary<string, Func<SettingsItem, TextFormattingRunProperties, TextFormattingRunProperties>> FormatPropertySetters = new Dictionary<string, Func<SettingsItem, TextFormattingRunProperties, TextFormattingRunProperties>>
		{
			[nameof(ForegroundColor)] = (o, p) => p.SetForeground(o.ForegroundColor),
			[nameof(BackgroundColor)] = (o, p) => p.SetBackground(o.BackgroundColor),
			[nameof(IsItalic)] = (o, p) => p.SetItalic(o.IsItalic),
			[nameof(IsBold)] = (o, p) => p.SetBold(o.IsBold),
			[nameof(IsUnderline)] = (o, p) => o.IsUnderline ? p.SetTextDecorations(TextDecorations.Underline) : p.ClearTextDecorations(),
		};

		internal SettingsItem((string classificationId, string displayName) i)
		{
			ClassificationId = i.classificationId;
			DisplayName = i.displayName;
		}

		private Color _foregroundColor = Colors.Black;
		private Color _backgroundColor = Colors.Transparent;
		private bool _isItalic;
		private bool _isBold;
		private bool _isUnderline;

		public string ClassificationId { get; }

		public string DisplayName { get; }

		public Color ForegroundColor
		{
			get => _foregroundColor;
			set => Set(ref _foregroundColor, value);
		}

		public Color BackgroundColor
		{
			get => _backgroundColor;
			set => Set(ref _backgroundColor, value);
		}

		public bool IsItalic
		{
			get => _isItalic;
			set => Set(ref _isItalic, value);
		}

		public bool IsBold
		{
			get => _isBold;
			set => Set(ref _isBold, value);
		}

		public bool IsUnderline
		{
			get => _isUnderline;
			set => Set(ref _isUnderline, value);
		}

		internal TextFormattingRunProperties UpdateProperties(TextFormattingRunProperties p)
		{
			p = FormatPropertySetters[nameof(BackgroundColor)](this, p);
			p = FormatPropertySetters[nameof(ForegroundColor)](this, p);
			p = FormatPropertySetters[nameof(IsBold)](this, p);
			p = FormatPropertySetters[nameof(IsItalic)](this, p);
			p = FormatPropertySetters[nameof(IsUnderline)](this, p);
			return p;
		}

		// ReSharper disable once RedundantAssignment
		private void Set<TP>(ref TP oldValue, TP newValue, [CallerMemberName] string propertyName = "")
		{
			oldValue = newValue;
			OnOptionsChanged(new SettingsChangedEventArgs(this, propertyName));
		}

		private void OnOptionsChanged(SettingsChangedEventArgs e)
		{
			OptionsChanged?.Invoke(this, e);
		}

		public override string ToString()
		{
			return ClassificationId;
		}
	}
}