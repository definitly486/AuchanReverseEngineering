package io.appmetrica.analytics.impl;

import android.content.Context;
import android.util.SparseArray;
import io.appmetrica.analytics.AppMetrica;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ed, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0230ed {
    public abstract void a(int i);

    public final synchronized void a(Context context) {
        try {
            int iB = b();
            int libraryApiLevel = AppMetrica.getLibraryApiLevel();
            if (iB != libraryApiLevel) {
                if (iB < libraryApiLevel) {
                    SparseArray sparseArrayC = c();
                    while (true) {
                        iB++;
                        if (iB > libraryApiLevel) {
                            break;
                        }
                        InterfaceC0205dd interfaceC0205dd = (InterfaceC0205dd) sparseArrayC.get(iB);
                        if (interfaceC0205dd != null) {
                            interfaceC0205dd.a(context);
                        }
                    }
                }
                a(libraryApiLevel);
            }
        } catch (Throwable th) {
            throw th;
        }
    }

    public abstract int b();

    public abstract SparseArray c();

    public final int a() {
        return AppMetrica.getLibraryApiLevel();
    }
}
