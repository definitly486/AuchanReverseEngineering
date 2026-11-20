package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufStateStorage;

/* JADX INFO: loaded from: classes3.dex */
public final class Fo implements InterfaceC0357jb {
    @Override // io.appmetrica.analytics.impl.InterfaceC0357jb
    public final String a(Context context) {
        Am am;
        try {
            InterfaceC0318hn interfaceC0318hnA = C0292gn.a(Am.class);
            if (interfaceC0318hnA == null) {
                return null;
            }
            AbstractC0343in abstractC0343in = (AbstractC0343in) interfaceC0318hnA;
            ProtobufStateStorage<Object> protobufStateStorageA = abstractC0343in.a(context, abstractC0343in.a(context));
            if (protobufStateStorageA == null || (am = (Am) protobufStateStorageA.read()) == null) {
                return null;
            }
            return am.a;
        } catch (Throwable unused) {
            return null;
        }
    }
}
