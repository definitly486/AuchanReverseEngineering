package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufStateStorage;
import java.util.List;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.h8, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0303h8 {
    public final Context a;
    public final ProtobufStateStorage b;
    public final AbstractC0354j8 c;
    public final InterfaceC0604so d;
    public final Zm e;
    public final InterfaceC0391kj f;
    public final InterfaceC0339ij g;
    public final R6 h;
    public InterfaceC0329i8 i;

    public AbstractC0303h8(Context context, ProtobufStateStorage protobufStateStorage, AbstractC0354j8 abstractC0354j8, InterfaceC0604so interfaceC0604so, Zm zm, InterfaceC0391kj interfaceC0391kj, InterfaceC0339ij interfaceC0339ij, R6 r6, InterfaceC0329i8 interfaceC0329i8) {
        this.a = context;
        this.b = protobufStateStorage;
        this.c = abstractC0354j8;
        this.d = interfaceC0604so;
        this.e = zm;
        this.f = interfaceC0391kj;
        this.g = interfaceC0339ij;
        this.h = r6;
        this.i = interfaceC0329i8;
    }

    public final synchronized InterfaceC0329i8 a() {
        return this.i;
    }

    public final synchronized boolean b(InterfaceC0432m8 interfaceC0432m8) {
        try {
            boolean z = false;
            if (interfaceC0432m8.a() == EnumC0406l8.c) {
                return false;
            }
            if (Intrinsics.areEqual(interfaceC0432m8, this.i.b())) {
                return false;
            }
            List listA = (List) this.d.invoke(this.i.a(), interfaceC0432m8);
            boolean z2 = listA != null;
            if (listA == null) {
                listA = this.i.a();
            }
            if (this.c.a(interfaceC0432m8, this.i.b())) {
                z = true;
            } else {
                interfaceC0432m8 = (InterfaceC0432m8) this.i.b();
            }
            if (z || z2) {
                InterfaceC0329i8 interfaceC0329i8 = this.i;
                InterfaceC0329i8 interfaceC0329i9 = (InterfaceC0329i8) this.e.invoke(interfaceC0432m8, listA);
                this.i = interfaceC0329i9;
                this.b.save(interfaceC0329i9);
                AbstractC0677vj.a("Update distribution data: %s -> %s", interfaceC0329i8, this.i);
            }
            return z;
        } catch (Throwable th) {
            throw th;
        }
    }

    public final synchronized InterfaceC0432m8 c() {
        try {
            if (!this.g.a()) {
                InterfaceC0432m8 interfaceC0432m8 = (InterfaceC0432m8) this.f.invoke();
                this.g.b();
                if (interfaceC0432m8 != null) {
                    b(interfaceC0432m8);
                }
            }
        } catch (Throwable th) {
            throw th;
        }
        return (InterfaceC0432m8) this.i.b();
    }

    public final InterfaceC0432m8 a(InterfaceC0432m8 interfaceC0432m8) {
        InterfaceC0432m8 interfaceC0432m8C;
        this.h.a(this.a);
        synchronized (this) {
            b(interfaceC0432m8);
            interfaceC0432m8C = c();
        }
        return interfaceC0432m8C;
    }

    public final InterfaceC0432m8 b() {
        this.h.a(this.a);
        return c();
    }
}
