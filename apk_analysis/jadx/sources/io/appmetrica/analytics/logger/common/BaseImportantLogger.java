package io.appmetrica.analytics.logger.common;

import android.util.Log;
import io.appmetrica.analytics.logger.common.impl.a;
import io.appmetrica.analytics.logger.common.impl.b;
import io.appmetrica.analytics.logger.common.impl.c;
import io.appmetrica.analytics.logger.common.impl.d;
import java.util.ArrayList;

/* JADX INFO: loaded from: classes3.dex */
public abstract class BaseImportantLogger {
    private final c a;

    public BaseImportantLogger(String str) {
        this.a = new c(new d(str), new a(), new b());
    }

    public void info(String str, String str2, Object... objArr) {
        c cVar = this.a;
        cVar.b.getClass();
        ArrayList arrayListA = cVar.c.a(a.a(str, str2, objArr));
        int size = arrayListA.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayListA.get(i);
            i++;
            String str3 = (String) obj;
            String str4 = cVar.a.a;
            if (str3 == null) {
                str3 = "";
            }
            Log.println(4, str4, str3);
        }
    }
}
