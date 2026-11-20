package com.google.common.graph;

import com.google.common.base.Preconditions;
import com.google.common.base.Supplier;
import com.google.common.collect.ForwardingSet;
import java.util.Set;

/* JADX INFO: loaded from: classes2.dex */
final class InvalidatableSet<E> extends ForwardingSet<E> {
    private final Set<E> delegate;
    private final Supplier<String> errorMessage;
    private final Supplier<Boolean> validator;

    static <E> InvalidatableSet<E> of(Set<E> set, Supplier<Boolean> supplier, Supplier<String> supplier2) {
        return new InvalidatableSet<>((Set) Preconditions.checkNotNull(set), (Supplier) Preconditions.checkNotNull(supplier), (Supplier) Preconditions.checkNotNull(supplier2));
    }

    /* JADX INFO: Access modifiers changed from: protected */
    @Override // com.google.common.collect.ForwardingSet, com.google.common.collect.ForwardingCollection, com.google.common.collect.ForwardingObject
    public Set<E> delegate() {
        validate();
        return this.delegate;
    }

    private InvalidatableSet(Set<E> set, Supplier<Boolean> supplier, Supplier<String> supplier2) {
        this.delegate = set;
        this.validator = supplier;
        this.errorMessage = supplier2;
    }

    @Override // com.google.common.collect.ForwardingSet, java.util.Collection, java.util.Set
    public int hashCode() {
        return this.delegate.hashCode();
    }

    private void validate() {
        if (!this.validator.get().booleanValue()) {
            throw new IllegalStateException(this.errorMessage.get());
        }
    }
}
