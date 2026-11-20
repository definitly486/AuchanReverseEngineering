package kotlinx.serialization.encoding;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.jvm.functions.Function3;
import java.util.Collection;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.descriptors.SerialDescriptor;

/* JADX INFO: compiled from: Encoding.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class EncodingKt {
    public static final void encodeStructure(Encoder encoder, SerialDescriptor descriptor, Function1<? super CompositeEncoder, Unit> block) {
        Intrinsics.checkNotNullParameter(encoder, "<this>");
        Intrinsics.checkNotNullParameter(descriptor, "descriptor");
        Intrinsics.checkNotNullParameter(block, "block");
        CompositeEncoder compositeEncoderBeginStructure = encoder.beginStructure(descriptor);
        block.invoke(compositeEncoderBeginStructure);
        compositeEncoderBeginStructure.endStructure(descriptor);
    }

    public static final void encodeCollection(Encoder encoder, SerialDescriptor descriptor, int i, Function1<? super CompositeEncoder, Unit> block) {
        Intrinsics.checkNotNullParameter(encoder, "<this>");
        Intrinsics.checkNotNullParameter(descriptor, "descriptor");
        Intrinsics.checkNotNullParameter(block, "block");
        CompositeEncoder compositeEncoderBeginCollection = encoder.beginCollection(descriptor, i);
        block.invoke(compositeEncoderBeginCollection);
        compositeEncoderBeginCollection.endStructure(descriptor);
    }

    public static final <E> void encodeCollection(Encoder encoder, SerialDescriptor descriptor, Collection<? extends E> collection, Function3 block) {
        Intrinsics.checkNotNullParameter(encoder, "<this>");
        Intrinsics.checkNotNullParameter(descriptor, "descriptor");
        Intrinsics.checkNotNullParameter(collection, "collection");
        Intrinsics.checkNotNullParameter(block, "block");
        CompositeEncoder compositeEncoderBeginCollection = encoder.beginCollection(descriptor, collection.size());
        int i = 0;
        for (Object obj : collection) {
            int i2 = i + 1;
            if (i < 0) {
                CollectionsKt.throwIndexOverflow();
            }
            block.invoke(compositeEncoderBeginCollection, Integer.valueOf(i), obj);
            i = i2;
        }
        compositeEncoderBeginCollection.endStructure(descriptor);
    }
}
