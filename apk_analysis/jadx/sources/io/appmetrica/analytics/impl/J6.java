package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: loaded from: classes3.dex */
public final class J6 implements Xf {
    public static final I6 b = new I6();
    public final Xf a;

    /* JADX WARN: Multi-variable type inference failed */
    public J6() {
        this(null, 1, 0 == true ? 1 : 0);
    }

    @Override // io.appmetrica.analytics.impl.Xf
    public final String a() {
        return this.a.a();
    }

    public final boolean b() {
        try {
            String strA = this.a.a();
            return (strA == null || strA.length() <= 0 || StringsKt.contains$default((CharSequence) strA, (CharSequence) StringUtils.PROCESS_POSTFIX_DELIMITER, false, 2, (Object) null)) ? false : true;
        } catch (Throwable unused) {
            return false;
        }
    }

    public J6(Xf xf) {
        this.a = xf;
    }

    public final boolean a(String str) {
        try {
            String strA = this.a.a();
            if (strA != null && strA.length() > 0) {
                if (StringsKt.endsWith$default(strA, StringUtils.PROCESS_POSTFIX_DELIMITER + str, false, 2, (Object) null)) {
                    return true;
                }
            }
        } catch (Throwable unused) {
        }
        return false;
    }

    /* JADX WARN: Illegal instructions before constructor call */
    public /* synthetic */ J6(Xf xf, int i, DefaultConstructorMarker defaultConstructorMarker) {
        if ((i & 1) != 0) {
            b.getClass();
            xf = I6.a();
        }
        this(xf);
    }
}
