package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.backport.Consumer;
import java.io.File;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.pg, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0518pg implements Runnable {
    public final File a;
    public final Consumer b;

    public RunnableC0518pg(File file, C0690w6 c0690w6) {
        this.a = file;
        this.b = c0690w6;
    }

    @Override // java.lang.Runnable
    public final void run() {
        File[] fileArrListFiles;
        if (!this.a.exists() || !this.a.isDirectory() || (fileArrListFiles = this.a.listFiles()) == null || fileArrListFiles.length == 0) {
            return;
        }
        for (File file : fileArrListFiles) {
            try {
                this.b.consume(file);
            } catch (Throwable unused) {
            }
        }
    }
}
