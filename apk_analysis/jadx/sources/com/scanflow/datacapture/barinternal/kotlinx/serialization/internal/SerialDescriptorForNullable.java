package com.scanflow.datacapture.barinternal.kotlinx.serialization.internal;

import java.util.List;
import java.util.Set;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.descriptors.SerialDescriptor;
import kotlinx.serialization.descriptors.SerialKind;

/* JADX INFO: compiled from: NullableSerializer.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class SerialDescriptorForNullable implements SerialDescriptor, CachedNames {
    private final SerialDescriptor original;
    private final String serialName;
    private final Set serialNames;

    @Override // kotlinx.serialization.descriptors.SerialDescriptor
    public List getAnnotations() {
        return this.original.getAnnotations();
    }

    @Override // kotlinx.serialization.descriptors.SerialDescriptor
    public SerialDescriptor getElementDescriptor(int i) {
        return this.original.getElementDescriptor(i);
    }

    @Override // kotlinx.serialization.descriptors.SerialDescriptor
    public String getElementName(int i) {
        return this.original.getElementName(i);
    }

    @Override // kotlinx.serialization.descriptors.SerialDescriptor
    public int getElementsCount() {
        return this.original.getElementsCount();
    }

    @Override // kotlinx.serialization.descriptors.SerialDescriptor
    public SerialKind getKind() {
        return this.original.getKind();
    }

    @Override // kotlinx.serialization.descriptors.SerialDescriptor
    public boolean isElementOptional(int i) {
        return this.original.isElementOptional(i);
    }

    public SerialDescriptorForNullable(SerialDescriptor original) {
        Intrinsics.checkNotNullParameter(original, "original");
        this.original = original;
        this.serialName = original.getSerialName() + '?';
        this.serialNames = Platform_commonKt.cachedSerialNames(original);
    }

    public final SerialDescriptor getOriginal$kotlinx_serialization_core() {
        return this.original;
    }

    @Override // kotlinx.serialization.descriptors.SerialDescriptor
    public String getSerialName() {
        return this.serialName;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.CachedNames
    public Set getSerialNames() {
        return this.serialNames;
    }

    @Override // kotlinx.serialization.descriptors.SerialDescriptor
    public boolean isNullable() {
        return true;
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        return (obj instanceof SerialDescriptorForNullable) && Intrinsics.areEqual(this.original, ((SerialDescriptorForNullable) obj).original);
    }

    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(this.original);
        sb.append('?');
        return sb.toString();
    }

    public int hashCode() {
        return this.original.hashCode() * 31;
    }
}
