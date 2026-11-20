package com.google.common.collect;

import android.R;
import androidx.core.location.LocationRequestCompat;
import com.google.common.annotations.GwtCompatible;
import com.google.common.base.Preconditions;
import com.google.j2objc.annotations.Weak;
import java.util.Comparator;
import java.util.Spliterator;
import java.util.function.Consumer;
import java.util.function.DoubleConsumer;
import java.util.function.Function;
import java.util.function.IntConsumer;
import java.util.function.IntFunction;
import java.util.function.LongConsumer;
import java.util.function.Predicate;
import java.util.stream.IntStream;

/* JADX INFO: loaded from: classes2.dex */
@GwtCompatible
@IgnoreJRERequirement
final class CollectSpliterators {
    private CollectSpliterators() {
    }

    static <T> Spliterator<T> indexed(int i, int i2, IntFunction<T> intFunction) {
        return indexed(i, i2, intFunction, null);
    }

    /* JADX WARN: Type inference failed for: r2v2, types: [java.util.Spliterator$OfInt] */
    static <T> Spliterator<T> indexed(int i, int i2, IntFunction<T> intFunction, Comparator<? super T> comparator) {
        if (comparator != null) {
            Preconditions.checkArgument((i2 & 4) != 0);
        }
        return new C1WithCharacteristics(IntStream.range(0, i).spliterator(), intFunction, i2, comparator);
    }

    /* JADX INFO: Add missing generic type declarations: [T] */
    /* JADX INFO: renamed from: com.google.common.collect.CollectSpliterators$1WithCharacteristics, reason: invalid class name */
    @IgnoreJRERequirement
    final class C1WithCharacteristics<T> implements Spliterator<T> {
        private final Spliterator.OfInt delegate;
        final /* synthetic */ Comparator val$comparator;
        final /* synthetic */ int val$extraCharacteristics;
        final /* synthetic */ IntFunction val$function;

        C1WithCharacteristics(Spliterator.OfInt ofInt, IntFunction intFunction, int i, Comparator comparator) {
            this.val$function = intFunction;
            this.val$extraCharacteristics = i;
            this.val$comparator = comparator;
            this.delegate = ofInt;
        }

        @Override // java.util.Spliterator
        public boolean tryAdvance(final Consumer<? super T> consumer) {
            Spliterator.OfInt ofInt = this.delegate;
            final IntFunction intFunction = this.val$function;
            return ofInt.tryAdvance(new IntConsumer() { // from class: com.google.common.collect.CollectSpliterators$1WithCharacteristics$$ExternalSyntheticLambda1
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    consumer.accept(intFunction.apply(i));
                }
            });
        }

        @Override // java.util.Spliterator
        public void forEachRemaining(final Consumer<? super T> consumer) {
            Spliterator.OfInt ofInt = this.delegate;
            final IntFunction intFunction = this.val$function;
            ofInt.forEachRemaining(new IntConsumer() { // from class: com.google.common.collect.CollectSpliterators$1WithCharacteristics$$ExternalSyntheticLambda0
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    consumer.accept(intFunction.apply(i));
                }
            });
        }

        @Override // java.util.Spliterator
        public Spliterator<T> trySplit() {
            Spliterator.OfInt ofIntTrySplit = this.delegate.trySplit();
            if (ofIntTrySplit == null) {
                return null;
            }
            return new C1WithCharacteristics(ofIntTrySplit, this.val$function, this.val$extraCharacteristics, this.val$comparator);
        }

        @Override // java.util.Spliterator
        public long estimateSize() {
            return this.delegate.estimateSize();
        }

        @Override // java.util.Spliterator
        public int characteristics() {
            return this.val$extraCharacteristics | 16464;
        }

        @Override // java.util.Spliterator
        public Comparator<? super T> getComparator() {
            if (hasCharacteristics(4)) {
                return this.val$comparator;
            }
            throw new IllegalStateException();
        }
    }

    static <InElementT, OutElementT> Spliterator<OutElementT> map(Spliterator<InElementT> spliterator, Function<? super InElementT, ? extends OutElementT> function) {
        Preconditions.checkNotNull(spliterator);
        Preconditions.checkNotNull(function);
        return new AnonymousClass1(spliterator, function);
    }

    /* JADX INFO: Add missing generic type declarations: [OutElementT] */
    /* JADX INFO: renamed from: com.google.common.collect.CollectSpliterators$1, reason: invalid class name */
    class AnonymousClass1<OutElementT> implements Spliterator<OutElementT> {
        final /* synthetic */ Spliterator val$fromSpliterator;
        final /* synthetic */ Function val$function;

        AnonymousClass1(Spliterator spliterator, Function function) {
            this.val$fromSpliterator = spliterator;
            this.val$function = function;
        }

        @Override // java.util.Spliterator
        public boolean tryAdvance(final Consumer<? super OutElementT> consumer) {
            Spliterator spliterator = this.val$fromSpliterator;
            final Function function = this.val$function;
            return spliterator.tryAdvance(new Consumer() { // from class: com.google.common.collect.CollectSpliterators$1$$ExternalSyntheticLambda1
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    consumer.accept(function.apply(obj));
                }
            });
        }

        @Override // java.util.Spliterator
        public void forEachRemaining(final Consumer<? super OutElementT> consumer) {
            Spliterator spliterator = this.val$fromSpliterator;
            final Function function = this.val$function;
            spliterator.forEachRemaining(new Consumer() { // from class: com.google.common.collect.CollectSpliterators$1$$ExternalSyntheticLambda0
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    consumer.accept(function.apply(obj));
                }
            });
        }

        @Override // java.util.Spliterator
        public Spliterator<OutElementT> trySplit() {
            Spliterator spliteratorTrySplit = this.val$fromSpliterator.trySplit();
            if (spliteratorTrySplit != null) {
                return CollectSpliterators.map(spliteratorTrySplit, this.val$function);
            }
            return null;
        }

        @Override // java.util.Spliterator
        public long estimateSize() {
            return this.val$fromSpliterator.estimateSize();
        }

        @Override // java.util.Spliterator
        public int characteristics() {
            return this.val$fromSpliterator.characteristics() & (-262);
        }
    }

    static <T> Spliterator<T> filter(Spliterator<T> spliterator, Predicate<? super T> predicate) {
        Preconditions.checkNotNull(spliterator);
        Preconditions.checkNotNull(predicate);
        return new C1Splitr(spliterator, predicate);
    }

    /* JADX INFO: Add missing generic type declarations: [T] */
    /* JADX INFO: renamed from: com.google.common.collect.CollectSpliterators$1Splitr, reason: invalid class name */
    @IgnoreJRERequirement
    final class C1Splitr<T> implements Spliterator<T>, Consumer<T> {
        T holder = null;
        final /* synthetic */ Spliterator val$fromSpliterator;
        final /* synthetic */ Predicate val$predicate;

        C1Splitr(Spliterator spliterator, Predicate predicate) {
            this.val$fromSpliterator = spliterator;
            this.val$predicate = predicate;
        }

        @Override // java.util.function.Consumer
        public void accept(@ParametricNullness T t) {
            this.holder = t;
        }

        @Override // java.util.Spliterator
        public boolean tryAdvance(Consumer<? super T> consumer) {
            while (this.val$fromSpliterator.tryAdvance(this)) {
                try {
                    R.anim animVar = (Object) NullnessCasts.uncheckedCastNullableTToT(this.holder);
                    if (this.val$predicate.test(animVar)) {
                        consumer.accept(animVar);
                        this.holder = null;
                        return true;
                    }
                    this.holder = null;
                } catch (Throwable th) {
                    this.holder = null;
                    throw th;
                }
            }
            return false;
        }

        @Override // java.util.Spliterator
        public Spliterator<T> trySplit() {
            Spliterator<T> spliteratorTrySplit = this.val$fromSpliterator.trySplit();
            if (spliteratorTrySplit == null) {
                return null;
            }
            return CollectSpliterators.filter(spliteratorTrySplit, this.val$predicate);
        }

        @Override // java.util.Spliterator
        public long estimateSize() {
            return this.val$fromSpliterator.estimateSize() / 2;
        }

        @Override // java.util.Spliterator
        public Comparator<? super T> getComparator() {
            return this.val$fromSpliterator.getComparator();
        }

        @Override // java.util.Spliterator
        public int characteristics() {
            return this.val$fromSpliterator.characteristics() & 277;
        }
    }

    static <InElementT, OutElementT> Spliterator<OutElementT> flatMap(Spliterator<InElementT> spliterator, Function<? super InElementT, Spliterator<OutElementT>> function, int i, long j) {
        Preconditions.checkArgument((i & 16384) == 0, "flatMap does not support SUBSIZED characteristic");
        Preconditions.checkArgument((i & 4) == 0, "flatMap does not support SORTED characteristic");
        Preconditions.checkNotNull(spliterator);
        Preconditions.checkNotNull(function);
        return new FlatMapSpliteratorOfObject(null, spliterator, function, i, j);
    }

    static <InElementT> Spliterator.OfInt flatMapToInt(Spliterator<InElementT> spliterator, Function<? super InElementT, Spliterator.OfInt> function, int i, long j) {
        Preconditions.checkArgument((i & 16384) == 0, "flatMap does not support SUBSIZED characteristic");
        Preconditions.checkArgument((i & 4) == 0, "flatMap does not support SORTED characteristic");
        Preconditions.checkNotNull(spliterator);
        Preconditions.checkNotNull(function);
        return new FlatMapSpliteratorOfInt(null, spliterator, function, i, j);
    }

    static <InElementT> Spliterator.OfLong flatMapToLong(Spliterator<InElementT> spliterator, Function<? super InElementT, Spliterator.OfLong> function, int i, long j) {
        Preconditions.checkArgument((i & 16384) == 0, "flatMap does not support SUBSIZED characteristic");
        Preconditions.checkArgument((i & 4) == 0, "flatMap does not support SORTED characteristic");
        Preconditions.checkNotNull(spliterator);
        Preconditions.checkNotNull(function);
        return new FlatMapSpliteratorOfLong(null, spliterator, function, i, j);
    }

    static <InElementT> Spliterator.OfDouble flatMapToDouble(Spliterator<InElementT> spliterator, Function<? super InElementT, Spliterator.OfDouble> function, int i, long j) {
        Preconditions.checkArgument((i & 16384) == 0, "flatMap does not support SUBSIZED characteristic");
        Preconditions.checkArgument((i & 4) == 0, "flatMap does not support SORTED characteristic");
        Preconditions.checkNotNull(spliterator);
        Preconditions.checkNotNull(function);
        return new FlatMapSpliteratorOfDouble(null, spliterator, function, i, j);
    }

    @IgnoreJRERequirement
    static abstract class FlatMapSpliterator<InElementT, OutElementT, OutSpliteratorT extends Spliterator<OutElementT>> implements Spliterator<OutElementT> {
        int characteristics;
        long estimatedSize;
        final Factory<InElementT, OutSpliteratorT> factory;
        final Spliterator<InElementT> from;
        final Function<? super InElementT, OutSpliteratorT> function;

        @Weak
        OutSpliteratorT prefix;

        @IgnoreJRERequirement
        interface Factory<InElementT, OutSpliteratorT extends Spliterator<?>> {
            OutSpliteratorT newFlatMapSpliterator(OutSpliteratorT outspliteratort, Spliterator<InElementT> spliterator, Function<? super InElementT, OutSpliteratorT> function, int i, long j);
        }

        FlatMapSpliterator(OutSpliteratorT outspliteratort, Spliterator<InElementT> spliterator, Function<? super InElementT, OutSpliteratorT> function, Factory<InElementT, OutSpliteratorT> factory, int i, long j) {
            this.prefix = outspliteratort;
            this.from = spliterator;
            this.function = function;
            this.factory = factory;
            this.characteristics = i;
            this.estimatedSize = j;
        }

        @Override // java.util.Spliterator
        public boolean tryAdvance(Consumer<? super OutElementT> consumer) {
            do {
                OutSpliteratorT outspliteratort = this.prefix;
                if (outspliteratort != null && outspliteratort.tryAdvance(consumer)) {
                    long j = this.estimatedSize;
                    if (j == LocationRequestCompat.PASSIVE_INTERVAL) {
                        return true;
                    }
                    this.estimatedSize = j - 1;
                    return true;
                }
                this.prefix = null;
            } while (this.from.tryAdvance(new Consumer() { // from class: com.google.common.collect.CollectSpliterators$FlatMapSpliterator$$ExternalSyntheticLambda1
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    CollectSpliterators.FlatMapSpliterator flatMapSpliterator = this.f$0;
                    flatMapSpliterator.prefix = flatMapSpliterator.function.apply(obj);
                }
            }));
            return false;
        }

        @Override // java.util.Spliterator
        public void forEachRemaining(final Consumer<? super OutElementT> consumer) {
            OutSpliteratorT outspliteratort = this.prefix;
            if (outspliteratort != null) {
                outspliteratort.forEachRemaining(consumer);
                this.prefix = null;
            }
            this.from.forEachRemaining(new Consumer() { // from class: com.google.common.collect.CollectSpliterators$FlatMapSpliterator$$ExternalSyntheticLambda0
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    CollectSpliterators.FlatMapSpliterator.$r8$lambda$V4UPWRzlfRNk1DlXgSbUsbldilw(this.f$0, consumer, obj);
                }
            });
            this.estimatedSize = 0L;
        }

        public static /* synthetic */ void $r8$lambda$V4UPWRzlfRNk1DlXgSbUsbldilw(FlatMapSpliterator flatMapSpliterator, Consumer consumer, Object obj) {
            OutSpliteratorT outspliteratortApply = flatMapSpliterator.function.apply(obj);
            if (outspliteratortApply != null) {
                outspliteratortApply.forEachRemaining(consumer);
            }
        }

        @Override // java.util.Spliterator
        public final OutSpliteratorT trySplit() {
            Spliterator<InElementT> spliteratorTrySplit = this.from.trySplit();
            if (spliteratorTrySplit != null) {
                int i = this.characteristics & (-65);
                long jEstimateSize = estimateSize();
                if (jEstimateSize < LocationRequestCompat.PASSIVE_INTERVAL) {
                    jEstimateSize /= 2;
                    this.estimatedSize -= jEstimateSize;
                    this.characteristics = i;
                }
                OutSpliteratorT outspliteratort = (OutSpliteratorT) this.factory.newFlatMapSpliterator(this.prefix, spliteratorTrySplit, this.function, i, jEstimateSize);
                this.prefix = null;
                return outspliteratort;
            }
            OutSpliteratorT outspliteratort2 = this.prefix;
            if (outspliteratort2 == null) {
                return null;
            }
            this.prefix = null;
            return outspliteratort2;
        }

        @Override // java.util.Spliterator
        public final long estimateSize() {
            OutSpliteratorT outspliteratort = this.prefix;
            if (outspliteratort != null) {
                this.estimatedSize = Math.max(this.estimatedSize, outspliteratort.estimateSize());
            }
            return Math.max(this.estimatedSize, 0L);
        }

        @Override // java.util.Spliterator
        public final int characteristics() {
            return this.characteristics;
        }
    }

    @IgnoreJRERequirement
    static final class FlatMapSpliteratorOfObject<InElementT, OutElementT> extends FlatMapSpliterator<InElementT, OutElementT, Spliterator<OutElementT>> {
        FlatMapSpliteratorOfObject(Spliterator<OutElementT> spliterator, Spliterator<InElementT> spliterator2, Function<? super InElementT, Spliterator<OutElementT>> function, int i, long j) {
            super(spliterator, spliterator2, function, new FlatMapSpliterator.Factory() { // from class: com.google.common.collect.CollectSpliterators$FlatMapSpliteratorOfObject$$ExternalSyntheticLambda0
                @Override // com.google.common.collect.CollectSpliterators.FlatMapSpliterator.Factory
                public final Spliterator newFlatMapSpliterator(Spliterator spliterator3, Spliterator spliterator4, Function function2, int i2, long j2) {
                    return new CollectSpliterators.FlatMapSpliteratorOfObject(spliterator3, spliterator4, function2, i2, j2);
                }
            }, i, j);
        }
    }

    @IgnoreJRERequirement
    static abstract class FlatMapSpliteratorOfPrimitive<InElementT, OutElementT, OutConsumerT, OutSpliteratorT extends Spliterator.OfPrimitive<OutElementT, OutConsumerT, OutSpliteratorT>> extends FlatMapSpliterator<InElementT, OutElementT, OutSpliteratorT> implements Spliterator.OfPrimitive<OutElementT, OutConsumerT, OutSpliteratorT> {
        @Override // com.google.common.collect.CollectSpliterators.FlatMapSpliterator, java.util.Spliterator
        public /* bridge */ /* synthetic */ Spliterator.OfPrimitive trySplit() {
            return (Spliterator.OfPrimitive) super.trySplit();
        }

        FlatMapSpliteratorOfPrimitive(OutSpliteratorT outspliteratort, Spliterator<InElementT> spliterator, Function<? super InElementT, OutSpliteratorT> function, FlatMapSpliterator.Factory<InElementT, OutSpliteratorT> factory, int i, long j) {
            super(outspliteratort, spliterator, function, factory, i, j);
        }

        @Override // java.util.Spliterator.OfPrimitive
        public final boolean tryAdvance(OutConsumerT outconsumert) {
            do {
                OutSpliteratorT outspliteratort = this.prefix;
                if (outspliteratort != 0 && ((Spliterator.OfPrimitive) outspliteratort).tryAdvance(outconsumert)) {
                    long j = this.estimatedSize;
                    if (j == LocationRequestCompat.PASSIVE_INTERVAL) {
                        return true;
                    }
                    this.estimatedSize = j - 1;
                    return true;
                }
                this.prefix = null;
            } while (this.from.tryAdvance(new Consumer() { // from class: com.google.common.collect.CollectSpliterators$FlatMapSpliteratorOfPrimitive$$ExternalSyntheticLambda1
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    CollectSpliterators.FlatMapSpliteratorOfPrimitive flatMapSpliteratorOfPrimitive = this.f$0;
                    flatMapSpliteratorOfPrimitive.prefix = (OutSpliteratorT) flatMapSpliteratorOfPrimitive.function.apply((Object) obj);
                }
            }));
            return false;
        }

        @Override // java.util.Spliterator.OfPrimitive
        public final void forEachRemaining(final OutConsumerT outconsumert) {
            OutSpliteratorT outspliteratort = this.prefix;
            if (outspliteratort != 0) {
                ((Spliterator.OfPrimitive) outspliteratort).forEachRemaining(outconsumert);
                this.prefix = null;
            }
            this.from.forEachRemaining(new Consumer() { // from class: com.google.common.collect.CollectSpliterators$FlatMapSpliteratorOfPrimitive$$ExternalSyntheticLambda0
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    CollectSpliterators.FlatMapSpliteratorOfPrimitive.$r8$lambda$crlWQ1f_z3XshnEQ43so28xfrBA(this.f$0, outconsumert, obj);
                }
            });
            this.estimatedSize = 0L;
        }

        /* JADX WARN: Type inference incomplete: some casts might be missing */
        public static /* synthetic */ void $r8$lambda$crlWQ1f_z3XshnEQ43so28xfrBA(FlatMapSpliteratorOfPrimitive flatMapSpliteratorOfPrimitive, Object obj, Object obj2) {
            Spliterator.OfPrimitive ofPrimitive = (Spliterator.OfPrimitive) flatMapSpliteratorOfPrimitive.function.apply((Object) obj2);
            if (ofPrimitive != null) {
                ofPrimitive.forEachRemaining(obj);
            }
        }
    }

    @IgnoreJRERequirement
    static final class FlatMapSpliteratorOfInt<InElementT> extends FlatMapSpliteratorOfPrimitive<InElementT, Integer, IntConsumer, Spliterator.OfInt> implements Spliterator.OfInt {
        @Override // java.util.Spliterator.OfInt
        public /* bridge */ /* synthetic */ void forEachRemaining(IntConsumer intConsumer) {
            super.forEachRemaining(intConsumer);
        }

        @Override // java.util.Spliterator.OfInt
        public /* bridge */ /* synthetic */ boolean tryAdvance(IntConsumer intConsumer) {
            return super.tryAdvance(intConsumer);
        }

        @Override // com.google.common.collect.CollectSpliterators.FlatMapSpliteratorOfPrimitive, com.google.common.collect.CollectSpliterators.FlatMapSpliterator, java.util.Spliterator
        public /* bridge */ /* synthetic */ Spliterator.OfInt trySplit() {
            return (Spliterator.OfInt) super.trySplit();
        }

        FlatMapSpliteratorOfInt(Spliterator.OfInt ofInt, Spliterator<InElementT> spliterator, Function<? super InElementT, Spliterator.OfInt> function, int i, long j) {
            super(ofInt, spliterator, function, new FlatMapSpliterator.Factory() { // from class: com.google.common.collect.CollectSpliterators$FlatMapSpliteratorOfInt$$ExternalSyntheticLambda0
                @Override // com.google.common.collect.CollectSpliterators.FlatMapSpliterator.Factory
                public final Spliterator newFlatMapSpliterator(Spliterator spliterator2, Spliterator spliterator3, Function function2, int i2, long j2) {
                    return new CollectSpliterators.FlatMapSpliteratorOfInt((Spliterator.OfInt) spliterator2, spliterator3, function2, i2, j2);
                }
            }, i, j);
        }
    }

    @IgnoreJRERequirement
    static final class FlatMapSpliteratorOfLong<InElementT> extends FlatMapSpliteratorOfPrimitive<InElementT, Long, LongConsumer, Spliterator.OfLong> implements Spliterator.OfLong {
        @Override // java.util.Spliterator.OfLong
        public /* bridge */ /* synthetic */ void forEachRemaining(LongConsumer longConsumer) {
            super.forEachRemaining(longConsumer);
        }

        @Override // java.util.Spliterator.OfLong
        public /* bridge */ /* synthetic */ boolean tryAdvance(LongConsumer longConsumer) {
            return super.tryAdvance(longConsumer);
        }

        @Override // com.google.common.collect.CollectSpliterators.FlatMapSpliteratorOfPrimitive, com.google.common.collect.CollectSpliterators.FlatMapSpliterator, java.util.Spliterator
        public /* bridge */ /* synthetic */ Spliterator.OfLong trySplit() {
            return (Spliterator.OfLong) super.trySplit();
        }

        FlatMapSpliteratorOfLong(Spliterator.OfLong ofLong, Spliterator<InElementT> spliterator, Function<? super InElementT, Spliterator.OfLong> function, int i, long j) {
            super(ofLong, spliterator, function, new FlatMapSpliterator.Factory() { // from class: com.google.common.collect.CollectSpliterators$FlatMapSpliteratorOfLong$$ExternalSyntheticLambda0
                @Override // com.google.common.collect.CollectSpliterators.FlatMapSpliterator.Factory
                public final Spliterator newFlatMapSpliterator(Spliterator spliterator2, Spliterator spliterator3, Function function2, int i2, long j2) {
                    return new CollectSpliterators.FlatMapSpliteratorOfLong((Spliterator.OfLong) spliterator2, spliterator3, function2, i2, j2);
                }
            }, i, j);
        }
    }

    @IgnoreJRERequirement
    static final class FlatMapSpliteratorOfDouble<InElementT> extends FlatMapSpliteratorOfPrimitive<InElementT, Double, DoubleConsumer, Spliterator.OfDouble> implements Spliterator.OfDouble {
        @Override // java.util.Spliterator.OfDouble
        public /* bridge */ /* synthetic */ void forEachRemaining(DoubleConsumer doubleConsumer) {
            super.forEachRemaining(doubleConsumer);
        }

        @Override // java.util.Spliterator.OfDouble
        public /* bridge */ /* synthetic */ boolean tryAdvance(DoubleConsumer doubleConsumer) {
            return super.tryAdvance(doubleConsumer);
        }

        @Override // com.google.common.collect.CollectSpliterators.FlatMapSpliteratorOfPrimitive, com.google.common.collect.CollectSpliterators.FlatMapSpliterator, java.util.Spliterator
        public /* bridge */ /* synthetic */ Spliterator.OfDouble trySplit() {
            return (Spliterator.OfDouble) super.trySplit();
        }

        FlatMapSpliteratorOfDouble(Spliterator.OfDouble ofDouble, Spliterator<InElementT> spliterator, Function<? super InElementT, Spliterator.OfDouble> function, int i, long j) {
            super(ofDouble, spliterator, function, new FlatMapSpliterator.Factory() { // from class: com.google.common.collect.CollectSpliterators$FlatMapSpliteratorOfDouble$$ExternalSyntheticLambda0
                @Override // com.google.common.collect.CollectSpliterators.FlatMapSpliterator.Factory
                public final Spliterator newFlatMapSpliterator(Spliterator spliterator2, Spliterator spliterator3, Function function2, int i2, long j2) {
                    return new CollectSpliterators.FlatMapSpliteratorOfDouble((Spliterator.OfDouble) spliterator2, spliterator3, function2, i2, j2);
                }
            }, i, j);
        }
    }
}
