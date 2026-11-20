package com.google.common.base;

import com.google.common.annotations.GwtCompatible;
import com.google.common.annotations.GwtIncompatible;
import com.google.common.annotations.J2ktIncompatible;
import com.google.errorprone.annotations.DoNotMock;
import java.io.Serializable;
import java.util.Iterator;
import java.util.Set;

/* JADX INFO: loaded from: classes2.dex */
@DoNotMock("Use Optional.of(value) or Optional.absent()")
@GwtCompatible
public abstract class Optional<T> implements Serializable {

    @J2ktIncompatible
    @GwtIncompatible
    private static final long serialVersionUID = 0;

    public abstract Set<T> asSet();

    public abstract boolean equals(Object obj);

    public abstract T get();

    public abstract int hashCode();

    public abstract boolean isPresent();

    public abstract Optional<T> or(Optional<? extends T> optional);

    public abstract T or(Supplier<? extends T> supplier);

    public abstract T or(T t);

    public abstract T orNull();

    public abstract String toString();

    public abstract <V> Optional<V> transform(Function<? super T, V> function);

    public static <T> Optional<T> absent() {
        return Absent.withType();
    }

    public static <T> Optional<T> of(T t) {
        return new Present(Preconditions.checkNotNull(t));
    }

    public static <T> Optional<T> fromNullable(T t) {
        return t == null ? absent() : new Present(t);
    }

    @IgnoreJRERequirement
    public static <T> Optional<T> fromJavaUtil(java.util.Optional<T> optional) {
        if (optional == null) {
            return null;
        }
        return fromNullable(optional.orElse(null));
    }

    @IgnoreJRERequirement
    public static <T> java.util.Optional<T> toJavaUtil(Optional<T> optional) {
        if (optional == null) {
            return null;
        }
        return optional.toJavaUtil();
    }

    @IgnoreJRERequirement
    public java.util.Optional<T> toJavaUtil() {
        return java.util.Optional.ofNullable(orNull());
    }

    Optional() {
    }

    public static <T> Iterable<T> presentInstances(final Iterable<? extends Optional<? extends T>> iterable) {
        Preconditions.checkNotNull(iterable);
        return new Iterable() { // from class: com.google.common.base.Optional$$ExternalSyntheticLambda0
            @Override // java.lang.Iterable
            public final Iterator iterator() {
                return Optional.$r8$lambda$WrBekaCHgZXf9frPnRGtVx8fOxU(iterable);
            }
        };
    }

    public static /* synthetic */ Iterator $r8$lambda$WrBekaCHgZXf9frPnRGtVx8fOxU(Iterable iterable) {
        return new AbstractIterator<T>(iterable) { // from class: com.google.common.base.Optional.1
            private final Iterator<? extends Optional<? extends T>> iterator;
            final /* synthetic */ Iterable val$optionals;

            {
                this.val$optionals = iterable;
                this.iterator = (Iterator) Preconditions.checkNotNull(iterable.iterator());
            }

            @Override // com.google.common.base.AbstractIterator
            protected T computeNext() {
                while (this.iterator.hasNext()) {
                    Optional<? extends T> next = this.iterator.next();
                    if (next.isPresent()) {
                        return next.get();
                    }
                }
                return endOfData();
            }
        };
    }
}
