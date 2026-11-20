package okhttp3.internal.proxy;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.io.IOException;
import java.net.Proxy;
import java.net.ProxySelector;
import java.net.SocketAddress;
import java.net.URI;
import java.util.List;

/* JADX INFO: compiled from: NullProxySelector.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class NullProxySelector extends ProxySelector {
    public static final NullProxySelector INSTANCE = new NullProxySelector();

    @Override // java.net.ProxySelector
    public void connectFailed(URI uri, SocketAddress socketAddress, IOException iOException) {
    }

    private NullProxySelector() {
    }

    @Override // java.net.ProxySelector
    public List<Proxy> select(URI uri) {
        if (uri == null) {
            throw new IllegalArgumentException("uri must not be null");
        }
        return CollectionsKt.listOf(Proxy.NO_PROXY);
    }
}
