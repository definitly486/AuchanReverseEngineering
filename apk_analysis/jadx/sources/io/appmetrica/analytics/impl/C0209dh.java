package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.backport.Consumer;
import io.appmetrica.analytics.coreutils.internal.logger.LoggerStorage;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.HashMap;
import java.util.Set;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.dh, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0209dh {
    public final Context a;
    public final InterfaceC0653ul b;
    public final D6 c;
    public final Jb d = new Jb();
    public final G4 e = new G4(new C0551qm(), new F4(), null);
    public final Consumer f;

    public C0209dh(Context context, final InterfaceC0612t6 interfaceC0612t6, final EnumC0721xb enumC0721xb, InterfaceC0653ul interfaceC0653ul, D6 d6) {
        this.a = context;
        this.b = interfaceC0653ul;
        this.c = d6;
        this.f = new Consumer() { // from class: io.appmetrica.analytics.impl.dh$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.coreapi.internal.backport.Consumer
            public final void consume(Object obj) {
                C0209dh.a(enumC0721xb, this, interfaceC0612t6, (Fb) obj);
            }
        };
    }

    public static final void a(EnumC0721xb enumC0721xb, C0209dh c0209dh, InterfaceC0612t6 interfaceC0612t6, Fb fb) {
        String str = fb.h;
        C0273g4 c0273g4 = new C0273g4(str, fb.e, fb.f, fb.g, fb.i);
        String str2 = fb.b;
        byte[] bArr = fb.a;
        int i = fb.c;
        HashMap map = fb.d;
        String str3 = fb.j;
        PublicLogger orCreatePublicLogger = LoggerStorage.getOrCreatePublicLogger(str);
        long jA = ((C0616ta) c0209dh.c).a(fb);
        Set set = Q9.a;
        C0196d4 c0196d4 = new C0196d4(bArr, str2, enumC0721xb.a, orCreatePublicLogger);
        c0196d4.b(jA);
        c0196d4.q = map;
        c0196d4.g = i;
        c0196d4.c = str3;
        ((C0157bh) interfaceC0612t6).a(c0273g4, c0196d4, c0209dh.e);
    }
}
