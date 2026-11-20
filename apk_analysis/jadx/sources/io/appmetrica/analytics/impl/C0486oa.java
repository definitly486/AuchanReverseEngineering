package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;
import io.appmetrica.analytics.coreapi.internal.identifiers.IdentifierStatus;
import io.appmetrica.analytics.internal.IdentifiersResult;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.oa, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0486oa {
    public final C0394km a = new C0394km();
    public C0539qa b = new C0539qa();

    public final synchronized void a(C0539qa c0539qa) {
        this.b = c0539qa;
    }

    public final synchronized void a(List list, HashMap map) {
        Boolean bool;
        String str;
        try {
            Iterator it = list.iterator();
            while (it.hasNext()) {
                if (Intrinsics.areEqual((String) it.next(), "appmetrica_lib_ssl_enabled") && (bool = this.b.a) != null) {
                    boolean zBooleanValue = bool.booleanValue();
                    C0539qa c0539qa = this.b;
                    IdentifierStatus identifierStatus = c0539qa.b;
                    String str2 = c0539qa.c;
                    if (zBooleanValue) {
                        str = "true";
                    } else {
                        if (zBooleanValue) {
                            throw new NoWhenBranchMatchedException();
                        }
                        str = "false";
                    }
                    map.put("appmetrica_lib_ssl_enabled", this.a.a(new IdentifiersResult(str, identifierStatus, str2)));
                }
            }
        } catch (Throwable th) {
            throw th;
        }
    }
}
