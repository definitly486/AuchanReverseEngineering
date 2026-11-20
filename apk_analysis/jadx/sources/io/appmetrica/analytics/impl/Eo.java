package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.internal.IdentifiersResult;

/* JADX INFO: loaded from: classes3.dex */
public final class Eo implements InterfaceC0357jb {
    @Override // io.appmetrica.analytics.impl.InterfaceC0357jb
    public final String a(Context context) {
        IdentifiersResult identifiersResultQ = C0584s4.l().b(context).q();
        if (StringUtils.isNullOrEmpty(identifiersResultQ.id)) {
            return null;
        }
        return identifiersResultQ.id;
    }
}
