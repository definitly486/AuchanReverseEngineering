using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.37416")]
internal sealed class _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__MainEmailPattern_0 : Regex
{
	private sealed class RunnerFactory : RegexRunnerFactory
	{
		private sealed class Runner : RegexRunner
		{
			protected override void Scan(ReadOnlySpan<char> inputSpan)
			{
				if (TryFindNextPossibleStartingPosition(inputSpan) && !TryMatchAtCurrentPosition(inputSpan))
				{
					runtextpos = inputSpan.Length;
				}
			}

			private bool TryFindNextPossibleStartingPosition(ReadOnlySpan<char> inputSpan)
			{
				int num = runtextpos;
				if (num <= inputSpan.Length - 6 && num == 0)
				{
					return true;
				}
				runtextpos = inputSpan.Length;
				return false;
			}

			private bool TryMatchAtCurrentPosition(ReadOnlySpan<char> inputSpan)
			{
				int num = runtextpos;
				int start = num;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				int num9 = 0;
				int arg = 0;
				int num10 = 0;
				int pos = 0;
				ReadOnlySpan<char> span = inputSpan.Slice(num);
				if (num != 0)
				{
					UncaptureUntil(0);
					return false;
				}
				int num11 = num;
				CheckTimeout();
				if ((uint)span.Length >= 65u && !span.Slice(0, 65).Contains('\n'))
				{
					UncaptureUntil(0);
					return false;
				}
				num = num11;
				span = inputSpan.Slice(num);
				num2 = num;
				int num12 = span.IndexOfAnyExcept(_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.s_ascii_68FF03FEFFFF87FEFFFF07);
				if (num12 < 0)
				{
					num12 = span.Length;
				}
				if (num12 == 0)
				{
					UncaptureUntil(0);
					return false;
				}
				span = span.Slice(num12);
				num += num12;
				Capture(1, num2, num);
				if (span.IsEmpty || span[0] != '@')
				{
					UncaptureUntil(0);
					return false;
				}
				num++;
				span = inputSpan.Slice(num);
				num3 = num;
				num7 = num;
				int num13 = span.IndexOfAnyExcept(_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.s_asciiLettersLowerAndDigits);
				if (num13 < 0)
				{
					num13 = span.Length;
				}
				if (num13 == 0)
				{
					UncaptureUntil(0);
					return false;
				}
				span = span.Slice(num13);
				num += num13;
				num8 = num;
				num7++;
				while (true)
				{
					num6 = Crawlpos();
					Capture(2, num3, num);
					num4 = num;
					num10 = 0;
					while (true)
					{
						_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPush(ref runstack, ref pos, Crawlpos(), num);
						num10++;
						int num14 = num;
						int num15 = num;
						int arg2 = num;
						int arg3 = Crawlpos();
						if (!span.IsEmpty && span[0] == '.')
						{
							span = span.Slice(1);
							num++;
						}
						_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPush(ref runstack, ref pos, 0, arg2, arg3);
						while (true)
						{
							Capture(5, num15, num);
							_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPush(ref runstack, ref pos, num15);
							num9 = num;
							int num16 = span.IndexOfAnyExcept(_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.s_asciiLettersLowerAndDigits);
							if (num16 < 0)
							{
								num16 = span.Length;
							}
							if (num16 == 0)
							{
								while (true)
								{
									num15 = runstack[--pos];
									CheckTimeout();
									_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPop(runstack, ref pos, out arg3, out arg2);
									int num17 = runstack[--pos];
									if (num17 == 0)
									{
										num = arg2;
										span = inputSpan.Slice(num);
										UncaptureUntil(arg3);
										int i;
										for (i = 0; i < 2 && (uint)i < (uint)span.Length; i++)
										{
											char c;
											if (!((c = span[i]) == '-' || c == '_'))
											{
												break;
											}
										}
										span = span.Slice(i);
										num += i;
										_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPush(ref runstack, ref pos, 1, arg2, arg3);
										break;
									}
									if (num17 != 1)
									{
										break;
									}
									if (--num10 < 0)
									{
										goto end_IL_017e;
									}
									num = runstack[--pos];
									UncaptureUntil(runstack[--pos]);
									span = inputSpan.Slice(num);
									Capture(3, num4, num);
									if (!span.IsEmpty && span[0] == '.')
									{
										num++;
										span = inputSpan.Slice(num);
										num5 = num;
										int num18 = span.IndexOfAnyExceptInRange('a', 'z');
										if (num18 < 0)
										{
											num18 = span.Length;
										}
										if (num18 >= 2)
										{
											span = span.Slice(num18);
											num += num18;
											Capture(6, num5, num);
											if (num >= inputSpan.Length - 1 && ((uint)num >= (uint)inputSpan.Length || inputSpan[num] == '\n'))
											{
												runtextpos = num;
												Capture(0, start, num);
												return true;
											}
										}
									}
									CheckTimeout();
									if (num10 != 0)
									{
										num14 = runstack[--pos];
										UncaptureUntil(runstack[--pos]);
										_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPop(runstack, ref pos, out arg, out num9);
										CheckTimeout();
										if (num9 >= arg)
										{
											continue;
										}
										goto IL_0325;
									}
									goto end_IL_017e;
								}
								continue;
							}
							span = span.Slice(num16);
							num += num16;
							arg = num;
							num9++;
							goto IL_0337;
							IL_0337:
							_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPush(ref runstack, ref pos, num9, arg, Crawlpos());
							Capture(4, num14, num);
							_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPush(ref runstack, ref pos, num14);
							break;
							IL_0325:
							num = --arg;
							span = inputSpan.Slice(num);
							goto IL_0337;
						}
						continue;
						end_IL_017e:
						break;
					}
					UncaptureUntil(num6);
					CheckTimeout();
					if (num7 >= num8)
					{
						break;
					}
					num = --num8;
					span = inputSpan.Slice(num);
				}
				UncaptureUntil(0);
				return false;
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				void UncaptureUntil(int capturePosition)
				{
					while (Crawlpos() > capturePosition)
					{
						Uncapture();
					}
				}
			}
		}

		protected override RegexRunner CreateInstance()
		{
			return new Runner();
		}
	}

	internal static readonly _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__MainEmailPattern_0 Instance = new _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__MainEmailPattern_0();

	private _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__MainEmailPattern_0()
	{
		pattern = "^(?!.{65})([abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0-9_\\-.+]+)@([a-z0-9]+)((([.]?|[_-]{0,2})[a-z0-9]+)*)\\.([a-z]{2,})$";
		roptions = RegexOptions.None;
		internalMatchTimeout = TimeSpan.FromMilliseconds(2147483647L);
		factory = new RunnerFactory();
		capsize = 7;
	}
}
