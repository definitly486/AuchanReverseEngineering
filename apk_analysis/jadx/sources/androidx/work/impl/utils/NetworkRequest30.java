package androidx.work.impl.utils;

import android.net.NetworkRequest;
import android.net.NetworkSpecifier;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: NetworkRequestCompat.kt */
/* JADX INFO: loaded from: classes.dex */
public final class NetworkRequest30 {
    public static final NetworkRequest30 INSTANCE = new NetworkRequest30();

    private NetworkRequest30() {
    }

    public final NetworkSpecifier getNetworkSpecifier(NetworkRequest request) {
        Intrinsics.checkNotNullParameter(request, "request");
        return request.getNetworkSpecifier();
    }
}
