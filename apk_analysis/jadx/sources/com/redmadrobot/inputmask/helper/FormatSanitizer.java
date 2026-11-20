package com.redmadrobot.inputmask.helper;

import com.scanflow.datacapture.barinternal.kotlin.TypeCastException;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import io.appmetrica.analytics.networktasks.internal.CommonUrlParts;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: FormatSanitizer.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class FormatSanitizer {
    public final String sanitize(String formatString) throws Compiler.FormatError {
        Intrinsics.checkParameterIsNotNull(formatString, "formatString");
        checkOpenBraces(formatString);
        return CollectionsKt.joinToString$default(sortFormatBlocks(divideBlocksWithMixedCharacters(getFormatBlocks(formatString))), "", null, null, 0, null, null, 62, null);
    }

    private final List<String> getFormatBlocks(String str) {
        ArrayList arrayList = new ArrayList();
        if (str != null) {
            char[] charArray = str.toCharArray();
            Intrinsics.checkExpressionValueIsNotNull(charArray, "(this as java.lang.String).toCharArray()");
            String str2 = "";
            boolean z = false;
            for (char c : charArray) {
                if ('\\' == c && !z) {
                    str2 = str2 + c;
                    z = true;
                } else {
                    if (('[' == c || '{' == c) && !z) {
                        if (str2.length() > 0) {
                            arrayList.add(str2);
                        }
                        str2 = "";
                    }
                    str2 = str2 + c;
                    if ((']' == c || '}' == c) && !z) {
                        arrayList.add(str2);
                        str2 = "";
                    }
                    z = false;
                }
            }
            if (str2.length() == 0) {
                return arrayList;
            }
            arrayList.add(str2);
            return arrayList;
        }
        throw new TypeCastException("null cannot be cast to non-null type java.lang.String");
    }

    private final List<String> divideBlocksWithMixedCharacters(List<String> list) {
        Iterator<String> it;
        Iterator<String> it2;
        boolean z;
        int i;
        String string;
        ArrayList arrayList = new ArrayList();
        Iterator<String> it3 = list.iterator();
        while (it3.hasNext()) {
            String next = it3.next();
            boolean z2 = false;
            int i2 = 2;
            if (StringsKt.startsWith$default(next, "[", false, 2, (Object) null)) {
                int length = next.length();
                String str = "";
                int i3 = 0;
                while (i3 < length) {
                    char cCharAt = next.charAt(i3);
                    if (cCharAt == '[') {
                        str = str + cCharAt;
                        it2 = it3;
                        z = z2;
                        i = i2;
                    } else {
                        if (cCharAt == ']' && !StringsKt.endsWith$default(str, "\\", z2, i2, (Object) null)) {
                            arrayList.add(str + cCharAt);
                            break;
                        }
                        if ((cCharAt == '0' || cCharAt == '9') && (StringsKt.contains$default(str, "A", z2, i2, (Object) null) || StringsKt.contains$default(str, "a", z2, i2, (Object) null) || StringsKt.contains$default(str, "-", z2, i2, (Object) null) || StringsKt.contains$default(str, "_", z2, i2, (Object) null))) {
                            it2 = it3;
                            z = z2;
                            i = i2;
                            arrayList.add(str + "]");
                            StringBuilder sb = new StringBuilder();
                            sb.append('[');
                            sb.append(cCharAt);
                            string = sb.toString();
                        } else {
                            if (cCharAt == 'A' || cCharAt == 'a') {
                                it2 = it3;
                                z = false;
                                i = 2;
                                if (StringsKt.contains$default((CharSequence) str, (CharSequence) CommonUrlParts.Values.FALSE_INTEGER, false, 2, (Object) null) || StringsKt.contains$default((CharSequence) str, (CharSequence) "9", false, 2, (Object) null) || StringsKt.contains$default((CharSequence) str, (CharSequence) "-", false, 2, (Object) null) || StringsKt.contains$default((CharSequence) str, (CharSequence) "_", false, 2, (Object) null)) {
                                    arrayList.add(str + "]");
                                    StringBuilder sb2 = new StringBuilder();
                                    sb2.append('[');
                                    sb2.append(cCharAt);
                                    string = sb2.toString();
                                }
                            } else {
                                it2 = it3;
                                z = false;
                                i = 2;
                            }
                            if ((cCharAt == '-' || cCharAt == '_') && (StringsKt.contains$default(str, CommonUrlParts.Values.FALSE_INTEGER, z, i, (Object) null) || StringsKt.contains$default(str, "9", z, i, (Object) null) || StringsKt.contains$default(str, "A", z, i, (Object) null) || StringsKt.contains$default(str, "a", z, i, (Object) null))) {
                                arrayList.add(str + "]");
                                StringBuilder sb3 = new StringBuilder();
                                sb3.append('[');
                                sb3.append(cCharAt);
                                string = sb3.toString();
                            } else {
                                string = str + cCharAt;
                            }
                        }
                        str = string;
                    }
                    i3++;
                    z2 = z;
                    i2 = i;
                    it3 = it2;
                }
                it = it3;
            } else {
                it = it3;
                arrayList.add(next);
            }
            it3 = it;
        }
        return arrayList;
    }

    private final List<String> sortFormatBlocks(List<String> list) {
        ArrayList arrayList = new ArrayList();
        for (String string : list) {
            if (StringsKt.startsWith$default(string, "[", false, 2, (Object) null)) {
                if (StringsKt.contains$default((CharSequence) string, (CharSequence) CommonUrlParts.Values.FALSE_INTEGER, false, 2, (Object) null) || StringsKt.contains$default((CharSequence) string, (CharSequence) "9", false, 2, (Object) null)) {
                    StringBuilder sb = new StringBuilder();
                    sb.append("[");
                    String strReplace$default = StringsKt.replace$default(StringsKt.replace$default(string, "[", "", false, 4, (Object) null), "]", "", false, 4, (Object) null);
                    if (strReplace$default == null) {
                        throw new TypeCastException("null cannot be cast to non-null type java.lang.String");
                    }
                    char[] charArray = strReplace$default.toCharArray();
                    Intrinsics.checkExpressionValueIsNotNull(charArray, "(this as java.lang.String).toCharArray()");
                    sb.append(CollectionsKt.joinToString$default(ArraysKt.sorted(charArray), "", null, null, 0, null, null, 62, null));
                    sb.append("]");
                    string = sb.toString();
                } else if (StringsKt.contains$default((CharSequence) string, (CharSequence) "a", false, 2, (Object) null) || StringsKt.contains$default((CharSequence) string, (CharSequence) "A", false, 2, (Object) null)) {
                    StringBuilder sb2 = new StringBuilder();
                    sb2.append("[");
                    String strReplace$default2 = StringsKt.replace$default(StringsKt.replace$default(string, "[", "", false, 4, (Object) null), "]", "", false, 4, (Object) null);
                    if (strReplace$default2 == null) {
                        throw new TypeCastException("null cannot be cast to non-null type java.lang.String");
                    }
                    char[] charArray2 = strReplace$default2.toCharArray();
                    Intrinsics.checkExpressionValueIsNotNull(charArray2, "(this as java.lang.String).toCharArray()");
                    sb2.append(CollectionsKt.joinToString$default(ArraysKt.sorted(charArray2), "", null, null, 0, null, null, 62, null));
                    sb2.append("]");
                    string = sb2.toString();
                } else {
                    StringBuilder sb3 = new StringBuilder();
                    sb3.append("[");
                    String strReplace$default3 = StringsKt.replace$default(StringsKt.replace$default(StringsKt.replace$default(StringsKt.replace$default(string, "[", "", false, 4, (Object) null), "]", "", false, 4, (Object) null), "_", "A", false, 4, (Object) null), "-", "a", false, 4, (Object) null);
                    if (strReplace$default3 != null) {
                        char[] charArray3 = strReplace$default3.toCharArray();
                        Intrinsics.checkExpressionValueIsNotNull(charArray3, "(this as java.lang.String).toCharArray()");
                        sb3.append(CollectionsKt.joinToString$default(ArraysKt.sorted(charArray3), "", null, null, 0, null, null, 62, null));
                        sb3.append("]");
                        string = StringsKt.replace$default(StringsKt.replace$default(sb3.toString(), "A", "_", false, 4, (Object) null), "a", "-", false, 4, (Object) null);
                    } else {
                        throw new TypeCastException("null cannot be cast to non-null type java.lang.String");
                    }
                }
            }
            arrayList.add(string);
        }
        return arrayList;
    }

    private final void checkOpenBraces(String str) throws Compiler.FormatError {
        if (str != null) {
            char[] charArray = str.toCharArray();
            Intrinsics.checkExpressionValueIsNotNull(charArray, "(this as java.lang.String).toCharArray()");
            boolean z = false;
            boolean z2 = false;
            boolean z3 = false;
            for (char c : charArray) {
                if ('\\' == c) {
                    z = !z;
                } else {
                    if ('[' == c) {
                        if (z2) {
                            throw new Compiler.FormatError();
                        }
                        z2 = !z;
                    }
                    if (']' == c && !z) {
                        z2 = false;
                    }
                    if ('{' == c) {
                        if (z3) {
                            throw new Compiler.FormatError();
                        }
                        z3 = !z;
                    }
                    if ('}' == c && !z) {
                        z3 = false;
                    }
                    z = false;
                }
            }
            return;
        }
        throw new TypeCastException("null cannot be cast to non-null type java.lang.String");
    }
}
