package androidx.lifecycle.internal;

import kotlin.reflect.KClass;

/* JADX INFO: compiled from: CanonicalName.jvm.kt */
/* JADX INFO: loaded from: classes.dex */
public final class CanonicalName_jvmKt {
    public static final String getCanonicalName(KClass<?> kClass) {
        if (kClass != null) {
            return kClass.getQualifiedName();
        }
        return null;
    }
}
