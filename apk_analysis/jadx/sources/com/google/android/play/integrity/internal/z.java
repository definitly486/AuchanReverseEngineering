package com.google.android.play.integrity.internal;

/* JADX INFO: compiled from: com.google.android.play:integrity@@1.1.0 */
/* JADX INFO: loaded from: classes2.dex */
public final class z implements ac {
    private static final Object a = new Object();
    private volatile ac b;
    private volatile Object c = a;

    private z(ac acVar) {
        this.b = acVar;
    }

    @Override // com.google.android.play.integrity.internal.ac
    public final Object a() {
        Object objA;
        Object obj = this.c;
        Object obj2 = a;
        if (obj != obj2) {
            return obj;
        }
        synchronized (this) {
            try {
                objA = this.c;
                if (objA == obj2) {
                    objA = this.b.a();
                    Object obj3 = this.c;
                    if (obj3 != obj2 && obj3 != objA) {
                        throw new IllegalStateException("Scoped provider was invoked recursively returning different results: " + obj3 + " & " + objA + ". This is likely due to a circular dependency.");
                    }
                    this.c = objA;
                    this.b = null;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return objA;
    }

    public static ac b(ac acVar) {
        acVar.getClass();
        return acVar instanceof z ? acVar : new z(acVar);
    }
}
