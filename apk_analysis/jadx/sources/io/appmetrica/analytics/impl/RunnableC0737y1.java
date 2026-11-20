package io.appmetrica.analytics.impl;

import android.content.Context;
import java.util.ArrayList;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.y1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0737y1 implements Runnable {
    public final /* synthetic */ Context a;

    public RunnableC0737y1(Context context) {
        this.a = context;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0263fk c0263fk = Dj.a;
        Context context = this.a;
        synchronized (c0263fk) {
            try {
                if (c0263fk.b == null) {
                    c0263fk.b = Ai.a.a(context, "20799a27-fa80-4b36-b2db-0f8141f24180");
                    ArrayList arrayList = c0263fk.a;
                    int size = arrayList.size();
                    int i = 0;
                    while (i < size) {
                        Object obj = arrayList.get(i);
                        i++;
                        ((InterfaceC0409lb) obj).a(c0263fk.b);
                    }
                    c0263fk.a.clear();
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }
}
