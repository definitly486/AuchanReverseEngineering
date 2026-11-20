package io.appmetrica.analytics.impl;

import android.os.FileObserver;
import android.text.TextUtils;
import io.appmetrica.analytics.coreapi.internal.backport.Consumer;
import java.io.File;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.u6, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class FileObserverC0638u6 extends FileObserver {
    public final Consumer a;
    public final File b;
    public final C0694wa c;

    public FileObserverC0638u6(File file, C0690w6 c0690w6, C0694wa c0694wa) {
        super(file.getAbsolutePath(), 8);
        this.a = c0690w6;
        this.b = file;
        this.c = c0694wa;
    }

    @Override // android.os.FileObserver
    public final void onEvent(int i, String str) {
        if (i != 8 || TextUtils.isEmpty(str)) {
            return;
        }
        Consumer consumer = this.a;
        C0694wa c0694wa = this.c;
        File file = this.b;
        c0694wa.getClass();
        consumer.consume(new File(file, str));
    }
}
