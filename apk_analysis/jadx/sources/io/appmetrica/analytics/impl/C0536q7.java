package io.appmetrica.analytics.impl;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.coreutils.internal.io.FileUtils;
import java.io.File;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.q7, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0536q7 {
    public final InterfaceC0121a7 a;
    public final List b;
    public final boolean c;

    public C0536q7(InterfaceC0121a7 interfaceC0121a7, ArrayList arrayList, boolean z) {
        this.a = interfaceC0121a7;
        this.b = arrayList;
        this.c = z;
    }

    public final String a(Context context, InterfaceC0483o7 interfaceC0483o7) {
        File parentFile;
        try {
            File fileA = this.a.a(context, interfaceC0483o7.b());
            if (!fileA.exists() && (parentFile = fileA.getParentFile()) != null && (parentFile.exists() || parentFile.mkdirs())) {
                a(context, interfaceC0483o7.a(), fileA);
            }
            return fileA.getPath();
        } catch (Throwable unused) {
            return interfaceC0483o7.b();
        }
    }

    public final void a(Context context, String str, File file) {
        List list = this.b;
        if ((list instanceof Collection) && list.isEmpty()) {
            return;
        }
        Iterator it = list.iterator();
        while (it.hasNext()) {
            File fileA = ((InterfaceC0121a7) it.next()).a(context, str);
            if (fileA.exists()) {
                try {
                    if (this.c) {
                        FileUtils.copyToNullable(fileA, file);
                    } else {
                        FileUtils.move(fileA, file);
                    }
                    String path = fileA.getPath();
                    String path2 = file.getPath();
                    for (String str2 : CollectionsKt.listOf((Object[]) new String[]{"-journal", "-shm", "-wal"})) {
                        File file2 = new File(path + str2);
                        File file3 = new File(path2 + str2);
                        if (this.c) {
                            FileUtils.copyToNullable(file2, file3);
                        } else {
                            FileUtils.move(file2, file3);
                        }
                    }
                    return;
                } catch (Throwable unused) {
                    continue;
                }
            }
        }
    }
}
