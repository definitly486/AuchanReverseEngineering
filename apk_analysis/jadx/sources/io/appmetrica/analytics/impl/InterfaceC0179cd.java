package io.appmetrica.analytics.impl;

import android.location.Location;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.cd, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public interface InterfaceC0179cd {
    void a(Location location);

    void a(String str);

    void a(String str, String str2);

    void a(boolean z);

    void a(boolean z, boolean z2);

    void clearAppEnvironment();

    void putAppEnvironmentValue(String str, String str2);

    void setDataSendingEnabled(boolean z);

    void setUserProfileID(String str);
}
