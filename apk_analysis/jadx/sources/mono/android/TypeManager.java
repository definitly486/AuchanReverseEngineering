package mono.android;

/* JADX INFO: loaded from: classes3.dex */
public class TypeManager {
    private static native void n_activate(String str, String str2, Object obj, Object[] objArr);

    public static void Activate(String str, String str2, Object obj, Object[] objArr) {
        n_activate(str, str2, obj, objArr);
    }
}
