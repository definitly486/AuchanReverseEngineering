package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.ICrashTransformer;

/* JADX INFO: loaded from: classes3.dex */
public final class Oh extends AbstractC0768z6 {
    public final AbstractC0500oo d;

    public Oh(Context context, AbstractC0500oo abstractC0500oo, InterfaceC0742y6 interfaceC0742y6, ICrashTransformer iCrashTransformer) {
        this(abstractC0500oo, interfaceC0742y6, iCrashTransformer, new C0305ha(context));
    }

    public Oh(AbstractC0500oo abstractC0500oo, InterfaceC0742y6 interfaceC0742y6, ICrashTransformer iCrashTransformer, C0305ha c0305ha) {
        super(interfaceC0742y6, iCrashTransformer, c0305ha);
        this.d = abstractC0500oo;
    }
}
