package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreutils.internal.io.FileUtils;
import java.io.BufferedOutputStream;
import java.io.Closeable;
import java.io.File;
import java.io.FileOutputStream;
import java.io.PrintWriter;

/* JADX INFO: loaded from: classes3.dex */
public final class E6 {
    public final C0694wa a;
    public final C0664v6 b;
    public final Context c;
    public final C0668va d;

    public E6(Context context) {
        this(context, new C0694wa(), new C0664v6(), C0668va.a(context));
    }

    /* JADX WARN: Code duplicated, block: B:30:0x0099 A[EXC_TOP_SPLITTER, SYNTHETIC] */
    public final void a(Ih ih) {
        boolean zMkdir;
        String str;
        R9 r9B;
        PrintWriter printWriter;
        C0668va c0668va;
        File crashesDirectory = FileUtils.getCrashesDirectory(this.c);
        this.b.getClass();
        if (crashesDirectory == null) {
            return;
        }
        try {
            try {
                if (crashesDirectory.exists()) {
                    if (!crashesDirectory.isDirectory()) {
                        if (!crashesDirectory.delete()) {
                            return;
                        } else {
                            zMkdir = crashesDirectory.mkdir();
                        }
                    }
                    Wf wf = ih.e.a;
                    str = wf.a.getAsInteger("PROCESS_CFG_PROCESS_ID") + "-" + wf.a.getAsString("PROCESS_CFG_PROCESS_SESSION_ID");
                    r9B = this.d.b(str);
                    r9B.a.lock();
                    r9B.b.a();
                    this.a.getClass();
                    printWriter = new PrintWriter(new BufferedOutputStream(new FileOutputStream(new File(crashesDirectory, str))));
                    printWriter.write(new Fb(ih.a, ih.e, ih.d).l());
                    Do.a((Closeable) printWriter);
                    r9B.c();
                    c0668va = this.d;
                    synchronized (c0668va) {
                        c0668va.b.remove(str);
                    }
                    return;
                }
                zMkdir = crashesDirectory.mkdir();
                printWriter.write(new Fb(ih.a, ih.e, ih.d).l());
                Do.a((Closeable) printWriter);
                r9B.c();
                c0668va = this.d;
                synchronized (c0668va) {
                    c0668va.b.remove(str);
                    return;
                }
            } catch (Throwable unused) {
                Do.a((Closeable) printWriter);
                r9B.c();
                this.d.a(str);
                return;
            }
            r9B.a.lock();
            r9B.b.a();
            this.a.getClass();
            printWriter = new PrintWriter(new BufferedOutputStream(new FileOutputStream(new File(crashesDirectory, str))));
        } catch (Throwable unused2) {
            printWriter = null;
        }
        if (!zMkdir) {
            return;
        }
        Wf wf2 = ih.e.a;
        str = wf2.a.getAsInteger("PROCESS_CFG_PROCESS_ID") + "-" + wf2.a.getAsString("PROCESS_CFG_PROCESS_SESSION_ID");
        r9B = this.d.b(str);
    }

    public E6(Context context, C0694wa c0694wa, C0664v6 c0664v6, C0668va c0668va) {
        this.c = context;
        this.a = c0694wa;
        this.b = c0664v6;
        this.d = c0668va;
    }
}
