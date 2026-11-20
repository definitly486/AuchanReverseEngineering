package com.google.android.play.core.integrity;

import android.content.Context;
import com.google.android.play.integrity.internal.aa;
import com.google.android.play.integrity.internal.ab;
import com.google.android.play.integrity.internal.ac;
import com.google.android.play.integrity.internal.z;

/* JADX INFO: compiled from: com.google.android.play:integrity@@1.1.0 */
/* JADX INFO: loaded from: classes2.dex */
final class j {
    private final j a = this;
    private final ac b;
    private final ac c;
    private final ac d;
    private final ac e;

    /* synthetic */ j(Context context, i iVar) {
        aa aaVarB = ab.b(context);
        this.b = aaVarB;
        ac acVarB = z.b(o.a);
        this.c = acVarB;
        ac acVarB2 = z.b(new v(aaVarB, acVarB));
        this.d = acVarB2;
        this.e = z.b(new n(acVarB2));
    }

    public final IntegrityManager a() {
        return (IntegrityManager) this.e.a();
    }
}
