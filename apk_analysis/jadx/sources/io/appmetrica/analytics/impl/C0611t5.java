package io.appmetrica.analytics.impl;

import android.content.Context;
import java.util.HashMap;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.t5, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0611t5 {
    public final HashMap a = new HashMap();
    public final HashMap b = new HashMap();
    public final Context c;

    public C0611t5(Context context) {
        this.c = context.getApplicationContext();
    }

    public final InterfaceC0254fb a(C0274g5 c0274g5, G4 g4, InterfaceC0277g8 interfaceC0277g8, HashMap map) {
        InterfaceC0254fb interfaceC0254fb = (InterfaceC0254fb) map.get(c0274g5.toString());
        if (interfaceC0254fb != null) {
            interfaceC0254fb.a(g4);
            return interfaceC0254fb;
        }
        InterfaceC0254fb interfaceC0254fbA = interfaceC0277g8.a(this.c, c0274g5, g4);
        map.put(c0274g5.toString(), interfaceC0254fbA);
        return interfaceC0254fbA;
    }
}
