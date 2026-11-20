package okio;

import com.scanflow.datacapture.barinternal.kotlin.collections.AbstractList;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.List;
import java.util.RandomAccess;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: TypedOptions.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class TypedOptions<T> extends AbstractList implements RandomAccess {
    public static final Companion Companion = new Companion(null);
    private final List list;
    private final Options options;

    public static final <T> TypedOptions<T> of(Iterable<? extends T> iterable, Function1<? super T, ? extends ByteString> function1) {
        return Companion.of(iterable, function1);
    }

    public final Options getOptions$okio() {
        return this.options;
    }

    public TypedOptions(List<? extends T> list, Options options) {
        Intrinsics.checkNotNullParameter(list, "list");
        Intrinsics.checkNotNullParameter(options, "options");
        this.options = options;
        List list2 = CollectionsKt.toList(list);
        this.list = list2;
        if (list2.size() != options.size()) {
            throw new IllegalArgumentException("Failed requirement.");
        }
    }

    @Override // com.scanflow.datacapture.barinternal.kotlin.collections.AbstractCollection
    public int getSize() {
        return this.list.size();
    }

    @Override // com.scanflow.datacapture.barinternal.kotlin.collections.AbstractList, java.util.List
    public T get(int i) {
        return (T) this.list.get(i);
    }

    /* JADX INFO: compiled from: TypedOptions.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }

        public final <T> TypedOptions<T> of(Iterable<? extends T> values, Function1<? super T, ? extends ByteString> encode) {
            Intrinsics.checkNotNullParameter(values, "values");
            Intrinsics.checkNotNullParameter(encode, "encode");
            List list = CollectionsKt.toList(values);
            Options.Companion companion = Options.Companion;
            int size = list.size();
            ByteString[] byteStringArr = new ByteString[size];
            for (int i = 0; i < size; i++) {
                byteStringArr[i] = encode.invoke((Object) list.get(i));
            }
            return new TypedOptions<>(list, companion.of(byteStringArr));
        }
    }
}
