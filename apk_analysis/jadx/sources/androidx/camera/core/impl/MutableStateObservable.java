package androidx.camera.core.impl;

/* JADX INFO: loaded from: classes.dex */
public class MutableStateObservable extends StateObservable {
    private MutableStateObservable(Object obj, boolean z) {
        super(obj, z);
    }

    public static MutableStateObservable withInitialState(Object obj) {
        return new MutableStateObservable(obj, false);
    }

    public void setState(Object obj) {
        updateState(obj);
    }

    public void setError(Throwable th) {
        updateStateAsError(th);
    }
}
