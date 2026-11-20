package kotlin.jvm.internal;

import com.scanflow.datacapture.barinternal.kotlin.jvm.KotlinReflectionNotSupportedError;
import java.util.Collection;

/* JADX INFO: compiled from: PackageReference.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class PackageReference implements ClassBasedDeclarationContainer {
    private final Class jClass;
    private final String moduleName;

    public PackageReference(Class jClass, String moduleName) {
        Intrinsics.checkNotNullParameter(jClass, "jClass");
        Intrinsics.checkNotNullParameter(moduleName, "moduleName");
        this.jClass = jClass;
        this.moduleName = moduleName;
    }

    @Override // kotlin.jvm.internal.ClassBasedDeclarationContainer
    public Class getJClass() {
        return this.jClass;
    }

    @Override // kotlin.reflect.KDeclarationContainer
    public Collection getMembers() {
        throw new KotlinReflectionNotSupportedError();
    }

    public boolean equals(Object obj) {
        return (obj instanceof PackageReference) && Intrinsics.areEqual(getJClass(), ((PackageReference) obj).getJClass());
    }

    public int hashCode() {
        return getJClass().hashCode();
    }

    public String toString() {
        return getJClass().toString() + " (Kotlin reflection is not available)";
    }
}
