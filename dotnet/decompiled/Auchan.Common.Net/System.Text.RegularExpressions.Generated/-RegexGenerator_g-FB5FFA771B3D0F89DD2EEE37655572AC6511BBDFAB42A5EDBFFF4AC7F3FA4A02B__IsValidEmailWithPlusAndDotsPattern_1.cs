using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.37416")]
internal sealed class _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__IsValidEmailWithPlusAndDotsPattern_1 : Regex
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
				int capturePosition = 0;
				int num10 = 0;
				int num11 = 0;
				int num12 = 0;
				int num13 = 0;
				int num14 = 0;
				int arg = 0;
				int arg2 = 0;
				int num15 = 0;
				int num16 = 0;
				int arg3 = 0;
				int arg4 = 0;
				int num17 = 0;
				int num18 = 0;
				int pos = 0;
				ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
				if (num != 0)
				{
					UncaptureUntil(0);
					return false;
				}
				num5 = num;
				int num19 = num;
				CheckTimeout();
				if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '.')
				{
					UncaptureUntil(0);
					return false;
				}
				num = num19;
				readOnlySpan = inputSpan.Slice(num);
				num11 = num;
				int i;
				for (i = 0; (uint)i < (uint)readOnlySpan.Length; i++)
				{
					char c;
					if ((((c = readOnlySpan[i]) < '\u0080') ? ("\0\0怀Ͽ\ufffe蟿\ufffe߿"[(int)c >> 4] & (1 << (c & 0xF))) : (RegexRunner.CharInClass(c, "\0\u0004\n-/_`\0\u0002\u0004\u0005\u0003\u0001\u0006\t\u0013\0") ? 1 : 0)) == 0)
					{
						break;
					}
				}
				readOnlySpan = readOnlySpan.Slice(i);
				num += i;
				num12 = num;
				while (true)
				{
					num9 = Crawlpos();
					char c;
					if (!readOnlySpan.IsEmpty && !(((c = readOnlySpan[0]) < '\u0080') ? (("쇿\uffff럾\uffff\uffff\uffff\uffff\uffff"[(int)c >> 4] & (1 << (c & 0xF))) == 0) : (!RegexRunner.CharInClass(c, "\u0001\u0004\u0001+,./d"))))
					{
						num++;
						readOnlySpan = inputSpan.Slice(num);
						Capture(1, num5, num);
						num6 = num;
						if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '@')
						{
							num++;
							readOnlySpan = inputSpan.Slice(num);
							num7 = num;
							num4 = num;
							num3 = Crawlpos();
							num13 = num;
							int j;
							for (j = 0; (uint)j < (uint)readOnlySpan.Length && _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.IsWordChar(readOnlySpan[j]); j++)
							{
							}
							if (j != 0)
							{
								readOnlySpan = readOnlySpan.Slice(j);
								num += j;
								num14 = num;
								num13++;
								goto IL_0245;
							}
							goto IL_0254;
						}
					}
					goto IL_0105;
					IL_03f9:
					CheckTimeout();
					int num20;
					if (num17 != 0)
					{
						num20 = runstack[--pos];
						UncaptureUntil(runstack[--pos]);
						_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPop(runstack, ref pos, out arg2, out arg);
						CheckTimeout();
						if (arg < arg2)
						{
							num = --arg2;
							readOnlySpan = inputSpan.Slice(num);
							goto IL_0373;
						}
						goto IL_03bd;
					}
					goto IL_0105;
					IL_0254:
					num = num4;
					readOnlySpan = inputSpan.Slice(num);
					UncaptureUntil(num3);
					num17 = 0;
					goto IL_026c;
					IL_026c:
					_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPush(ref runstack, ref pos, Crawlpos(), num);
					num17++;
					num20 = num;
					int k;
					for (k = 0; (uint)k < (uint)readOnlySpan.Length && _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.IsWordChar(readOnlySpan[k]); k++)
					{
					}
					if (k != 0)
					{
						readOnlySpan = readOnlySpan.Slice(k);
						num += k;
						if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '-')
						{
							num++;
							readOnlySpan = inputSpan.Slice(num);
							arg = num;
							int l;
							for (l = 0; (uint)l < (uint)readOnlySpan.Length && _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.IsWordChar(readOnlySpan[l]); l++)
							{
							}
							readOnlySpan = readOnlySpan.Slice(l);
							num += l;
							arg2 = num;
							goto IL_0373;
						}
					}
					goto IL_03bd;
					IL_0245:
					capturePosition = Crawlpos();
					num2 = 0;
					goto IL_041c;
					IL_0105:
					UncaptureUntil(num9);
					CheckTimeout();
					if (num11 >= num12)
					{
						break;
					}
					num = --num12;
					readOnlySpan = inputSpan.Slice(num);
					continue;
					IL_03bd:
					if (--num17 < 0)
					{
						goto IL_0105;
					}
					num = runstack[--pos];
					UncaptureUntil(runstack[--pos]);
					readOnlySpan = inputSpan.Slice(num);
					num2 = 1;
					goto IL_041c;
					IL_0373:
					_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPush(ref runstack, ref pos, arg, arg2, Crawlpos());
					Capture(4, num20, num);
					_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPush(ref runstack, ref pos, num20);
					goto IL_026c;
					IL_041c:
					while (true)
					{
						Capture(3, num7, num);
						Capture(2, num6, num);
						num8 = num;
						int m;
						for (m = 0; (uint)m < (uint)readOnlySpan.Length && _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.IsWordChar(readOnlySpan[m]); m++)
						{
						}
						if (m != 0)
						{
							readOnlySpan = readOnlySpan.Slice(m);
							num += m;
							if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '.')
							{
								num++;
								readOnlySpan = inputSpan.Slice(num);
								num15 = num;
								int n;
								for (n = 0; (uint)n < (uint)readOnlySpan.Length && _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.IsWordChar(readOnlySpan[n]); n++)
								{
								}
								if (n != 0)
								{
									readOnlySpan = readOnlySpan.Slice(n);
									num += n;
									num16 = num;
									num15++;
									while (true)
									{
										num10 = Crawlpos();
										num18 = 0;
										while (true)
										{
											_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPush(ref runstack, ref pos, Crawlpos(), num);
											num18++;
											int num21 = num;
											if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '.')
											{
												num++;
												readOnlySpan = inputSpan.Slice(num);
												arg3 = num;
												int num22;
												for (num22 = 0; (uint)num22 < (uint)readOnlySpan.Length && _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.IsWordChar(readOnlySpan[num22]); num22++)
												{
												}
												if (num22 != 0)
												{
													readOnlySpan = readOnlySpan.Slice(num22);
													num += num22;
													arg4 = num;
													arg3++;
													goto IL_05e8;
												}
											}
											goto IL_0638;
											IL_05e8:
											_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPush(ref runstack, ref pos, arg3, arg4, Crawlpos());
											Capture(6, num21, num);
											_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPush(ref runstack, ref pos, num21);
											if (num18 == 0)
											{
												continue;
											}
											goto IL_0683;
											IL_0683:
											if (!readOnlySpan.IsEmpty && !(((c = readOnlySpan[0]) < '\u0080') ? (("\0\0\0Ͽ\ufffe蟿\ufffe߿"[(int)c >> 4] & (1 << (c & 0xF))) == 0) : (!RegexRunner.CharInClass(c, "\u0001\u0002\n./\0\ufffe￼\ufffb\ufffd\uffff\ufffa\ufff7￭\0"))))
											{
												num++;
												readOnlySpan = inputSpan.Slice(num);
												Capture(5, num8, num);
												if (num >= inputSpan.Length - 1 && ((uint)num >= (uint)inputSpan.Length || inputSpan[num] == '\n'))
												{
													runtextpos = num;
													Capture(0, start, num);
													return true;
												}
											}
											CheckTimeout();
											if (num18 != 0)
											{
												num21 = runstack[--pos];
												UncaptureUntil(runstack[--pos]);
												_003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__Utilities.StackPop(runstack, ref pos, out arg4, out arg3);
												CheckTimeout();
												if (arg3 < arg4)
												{
													num = --arg4;
													readOnlySpan = inputSpan.Slice(num);
													goto IL_05e8;
												}
												goto IL_0638;
											}
											break;
											IL_0638:
											if (--num18 < 0)
											{
												break;
											}
											num = runstack[--pos];
											UncaptureUntil(runstack[--pos]);
											readOnlySpan = inputSpan.Slice(num);
											goto IL_0683;
										}
										UncaptureUntil(num10);
										CheckTimeout();
										if (num15 >= num16)
										{
											break;
										}
										num = --num16;
										readOnlySpan = inputSpan.Slice(num);
									}
								}
							}
						}
						CheckTimeout();
						if (num2 == 0)
						{
							break;
						}
						if (num2 != 1)
						{
							continue;
						}
						goto IL_03f9;
					}
					UncaptureUntil(capturePosition);
					CheckTimeout();
					if (num13 < num14)
					{
						num = --num14;
						readOnlySpan = inputSpan.Slice(num);
						goto IL_0245;
					}
					goto IL_0254;
				}
				UncaptureUntil(0);
				return false;
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				void UncaptureUntil(int num23)
				{
					while (Crawlpos() > num23)
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

	internal static readonly _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__IsValidEmailWithPlusAndDotsPattern_1 Instance = new _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__IsValidEmailWithPlusAndDotsPattern_1();

	private _003CRegexGenerator_g_003EFB5FFA771B3D0F89DD2EEE37655572AC6511BBDFAB42A5EDBFFF4AC7F3FA4A02B__IsValidEmailWithPlusAndDotsPattern_1()
	{
		pattern = "^((?!\\.)[\\w\\-_.]*[^.\\+\\s])(@(\\w+|(\\w+-\\w*)*))(\\w+\\.\\w+(\\.\\w+)?[^.\\W])$";
		roptions = RegexOptions.None;
		internalMatchTimeout = TimeSpan.FromMilliseconds(2147483647L);
		factory = new RunnerFactory();
		capsize = 7;
	}
}
