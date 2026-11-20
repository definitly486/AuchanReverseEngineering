package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.IBinaryDataHelper;
import java.util.HashSet;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.u2, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0634u2 extends AbstractC0131ah {
    public final Po b;
    public final C0496ok c;

    public C0634u2(C0455n5 c0455n5) {
        this(c0455n5, c0455n5.u(), C0496ok.c());
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        C0455n5 c0455n5 = this.a;
        if (!this.b.c() && !this.b.d()) {
            if (((C0727xh) c0455n5.k.a()).e) {
                C0496ok c0496ok = this.c;
                synchronized (c0496ok) {
                    c0496ok.b.d(false);
                }
            }
            C0278g9 c0278g9 = this.a.l;
            if (c0278g9.c == null) {
                c0278g9.a();
            }
            C0330i9 c0330i9 = c0278g9.c;
            c0330i9.getClass();
            c0330i9.b = new HashSet();
            c0330i9.d = 0;
            C0330i9 c0330i10 = c0278g9.c;
            c0330i10.a = true;
            C0407l9 c0407l9 = c0278g9.b;
            IBinaryDataHelper iBinaryDataHelper = c0407l9.c;
            C0381k9 c0381k9 = c0407l9.b;
            c0407l9.a.getClass();
            iBinaryDataHelper.insert("event_hashes", c0381k9.toByteArray(C0355j9.a(c0330i10)));
        }
        return false;
    }

    public C0634u2(C0455n5 c0455n5, Po po, C0496ok c0496ok) {
        super(c0455n5);
        this.b = po;
        this.c = c0496ok;
    }
}
