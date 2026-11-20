package io.appmetrica.analytics.profile;

import io.appmetrica.analytics.impl.InterfaceC0708wo;

/* JADX INFO: loaded from: classes3.dex */
public class UserProfileUpdate<T extends InterfaceC0708wo> {
    private final InterfaceC0708wo a;

    UserProfileUpdate(InterfaceC0708wo interfaceC0708wo) {
        this.a = interfaceC0708wo;
    }

    public T getUserProfileUpdatePatcher() {
        return (T) this.a;
    }
}
