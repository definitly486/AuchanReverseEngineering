package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufStateStorage;
import io.appmetrica.analytics.coreutils.internal.parsing.JsonUtils;
import java.util.Iterator;
import java.util.concurrent.CopyOnWriteArrayList;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ym, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0758ym implements Bm {
    public volatile C0706wm a;
    public final CopyOnWriteArrayList b = new CopyOnWriteArrayList();

    @Override // io.appmetrica.analytics.impl.Bm
    public final void a(C0706wm c0706wm) {
        this.a = c0706wm;
        Iterator it = this.b.iterator();
        while (it.hasNext()) {
            ((Bm) it.next()).a(c0706wm);
        }
    }

    public final void b(Bm bm) {
        this.b.remove(bm);
    }

    public final C0706wm a() {
        C0706wm c0706wm = this.a;
        if (c0706wm != null) {
            return c0706wm;
        }
        Intrinsics.throwUninitializedPropertyAccessException("startupState");
        return null;
    }

    public final void a(Bm bm) {
        this.b.add(bm);
        if (this.a != null) {
            C0706wm c0706wm = this.a;
            if (c0706wm == null) {
                Intrinsics.throwUninitializedPropertyAccessException("startupState");
                c0706wm = null;
            }
            bm.a(c0706wm);
        }
    }

    public final void a(Context context) {
        String strOptStringOrNull;
        ProtobufStateStorage<Object> protobufStateStorageCreate = ((AbstractC0343in) C0292gn.a(Am.class)).create(context);
        Oo ooA = Ka.k().D().a();
        synchronized (ooA) {
            strOptStringOrNull = JsonUtils.optStringOrNull(ooA.a.a(), "device_id");
        }
        a(new C0706wm(strOptStringOrNull, ooA.a(), (Am) protobufStateStorageCreate.read()));
    }
}
