package io.appmetrica.analytics.coreutils.internal.network;

import android.os.Build;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import io.appmetrica.analytics.coreutils.internal.StringExtensions;

/* JADX INFO: loaded from: classes3.dex */
public final class UserAgent {
    public static final UserAgent INSTANCE = new UserAgent();

    private UserAgent() {
    }

    public static final String getFor(String str, String str2, String str3) {
        StringBuilder sb = new StringBuilder();
        sb.append(str);
        sb.append('/');
        sb.append(str2);
        sb.append('.');
        sb.append(str3);
        sb.append(" (");
        INSTANCE.getClass();
        StringExtensions stringExtensions = StringExtensions.INSTANCE;
        String str4 = Build.MODEL;
        String str5 = Build.MANUFACTURER;
        if (!StringsKt.startsWith$default(str4, str5, false, 2, (Object) null)) {
            str4 = str5 + ' ' + str4;
        }
        sb.append(stringExtensions.replaceFirstCharWithTitleCase(str4));
        sb.append("; Android ");
        sb.append(Build.VERSION.RELEASE);
        sb.append(')');
        return sb.toString();
    }
}
