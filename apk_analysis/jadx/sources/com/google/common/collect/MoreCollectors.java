package com.google.common.collect;

import com.google.common.annotations.GwtCompatible;
import com.google.common.base.Preconditions;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.NoSuchElementException;
import java.util.Optional;
import java.util.function.BiConsumer;
import java.util.function.BinaryOperator;
import java.util.function.Function;
import java.util.function.Supplier;
import java.util.stream.Collector;

/* JADX INFO: loaded from: classes2.dex */
@GwtCompatible
@IgnoreJRERequirement
public final class MoreCollectors {
    private static final Object NULL_PLACEHOLDER;
    private static final Collector<Object, ?, Object> ONLY_ELEMENT;
    private static final Collector<Object, ?, Optional<Object>> TO_OPTIONAL;

    static {
        Supplier supplier = new Supplier() { // from class: com.google.common.collect.MoreCollectors$$ExternalSyntheticLambda0
            @Override // java.util.function.Supplier
            public final Object get() {
                return new MoreCollectors.ToOptionalState();
            }
        };
        BiConsumer biConsumer = new BiConsumer() { // from class: com.google.common.collect.MoreCollectors$$ExternalSyntheticLambda1
            @Override // java.util.function.BiConsumer
            public final void accept(Object obj, Object obj2) {
                ((MoreCollectors.ToOptionalState) obj).add(obj2);
            }
        };
        BinaryOperator binaryOperator = new BinaryOperator() { // from class: com.google.common.collect.MoreCollectors$$ExternalSyntheticLambda2
            @Override // java.util.function.BiFunction
            public final Object apply(Object obj, Object obj2) {
                return ((MoreCollectors.ToOptionalState) obj).combine((MoreCollectors.ToOptionalState) obj2);
            }
        };
        Function function = new Function() { // from class: com.google.common.collect.MoreCollectors$$ExternalSyntheticLambda3
            @Override // java.util.function.Function
            public final Object apply(Object obj) {
                return ((MoreCollectors.ToOptionalState) obj).getOptional();
            }
        };
        Collector.Characteristics characteristics = Collector.Characteristics.UNORDERED;
        TO_OPTIONAL = Collector.of(supplier, biConsumer, binaryOperator, function, characteristics);
        NULL_PLACEHOLDER = new Object();
        ONLY_ELEMENT = Collector.of(new Supplier() { // from class: com.google.common.collect.MoreCollectors$$ExternalSyntheticLambda0
            @Override // java.util.function.Supplier
            public final Object get() {
                return new MoreCollectors.ToOptionalState();
            }
        }, new BiConsumer() { // from class: com.google.common.collect.MoreCollectors$$ExternalSyntheticLambda4
            @Override // java.util.function.BiConsumer
            public final void accept(Object obj, Object obj2) {
                MoreCollectors.m287$r8$lambda$9X5rX0l5R2Beg_YEMtov6cqU8((MoreCollectors.ToOptionalState) obj, obj2);
            }
        }, new BinaryOperator() { // from class: com.google.common.collect.MoreCollectors$$ExternalSyntheticLambda2
            @Override // java.util.function.BiFunction
            public final Object apply(Object obj, Object obj2) {
                return ((MoreCollectors.ToOptionalState) obj).combine((MoreCollectors.ToOptionalState) obj2);
            }
        }, new Function() { // from class: com.google.common.collect.MoreCollectors$$ExternalSyntheticLambda5
            @Override // java.util.function.Function
            public final Object apply(Object obj) {
                return MoreCollectors.m288$r8$lambda$T8w15ZuYonXg5iTgVETfpFy7SQ((MoreCollectors.ToOptionalState) obj);
            }
        }, characteristics);
    }

    public static <T> Collector<T, ?, Optional<T>> toOptional() {
        return (Collector<T, ?, Optional<T>>) TO_OPTIONAL;
    }

    /* JADX INFO: renamed from: $r8$lambda$9X5rX0l5R2Beg_-YE-Mtov6cqU8, reason: not valid java name */
    public static /* synthetic */ void m287$r8$lambda$9X5rX0l5R2Beg_YEMtov6cqU8(ToOptionalState toOptionalState, Object obj) {
        if (obj == null) {
            obj = NULL_PLACEHOLDER;
        }
        toOptionalState.add(obj);
    }

    /* JADX INFO: renamed from: $r8$lambda$T8w15ZuYonXg5iTgVE-TfpFy7SQ, reason: not valid java name */
    public static /* synthetic */ Object m288$r8$lambda$T8w15ZuYonXg5iTgVETfpFy7SQ(ToOptionalState toOptionalState) {
        Object element = toOptionalState.getElement();
        if (element == NULL_PLACEHOLDER) {
            return null;
        }
        return element;
    }

    public static <T> Collector<T, ?, T> onlyElement() {
        return (Collector<T, ?, T>) ONLY_ELEMENT;
    }

    /* JADX INFO: Access modifiers changed from: private */
    static final class ToOptionalState {
        static final int MAX_EXTRAS = 4;
        Object element = null;
        List<Object> extras = Collections.EMPTY_LIST;

        ToOptionalState() {
        }

        IllegalArgumentException multiples(boolean z) {
            StringBuilder sb = new StringBuilder();
            sb.append("expected one element but was: <");
            sb.append(this.element);
            for (Object obj : this.extras) {
                sb.append(", ");
                sb.append(obj);
            }
            if (z) {
                sb.append(", ...");
            }
            sb.append('>');
            throw new IllegalArgumentException(sb.toString());
        }

        void add(Object obj) {
            Preconditions.checkNotNull(obj);
            if (this.element == null) {
                this.element = obj;
                return;
            }
            if (this.extras.isEmpty()) {
                ArrayList arrayList = new ArrayList(4);
                this.extras = arrayList;
                arrayList.add(obj);
            } else {
                if (this.extras.size() < 4) {
                    this.extras.add(obj);
                    return;
                }
                throw multiples(true);
            }
        }

        ToOptionalState combine(ToOptionalState toOptionalState) {
            if (this.element == null) {
                return toOptionalState;
            }
            if (toOptionalState.element != null) {
                if (this.extras.isEmpty()) {
                    this.extras = new ArrayList();
                }
                this.extras.add(toOptionalState.element);
                this.extras.addAll(toOptionalState.extras);
                if (this.extras.size() > 4) {
                    List<Object> list = this.extras;
                    list.subList(4, list.size()).clear();
                    throw multiples(true);
                }
            }
            return this;
        }

        @IgnoreJRERequirement
        Optional<Object> getOptional() {
            if (this.extras.isEmpty()) {
                return Optional.ofNullable(this.element);
            }
            throw multiples(false);
        }

        Object getElement() {
            if (this.element == null) {
                throw new NoSuchElementException();
            }
            if (this.extras.isEmpty()) {
                return this.element;
            }
            throw multiples(false);
        }
    }

    private MoreCollectors() {
    }
}
