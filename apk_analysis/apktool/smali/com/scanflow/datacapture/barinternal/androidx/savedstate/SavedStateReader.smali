.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;
.super Ljava/lang/Object;
.source "SavedStateReader.android.kt"


# direct methods
.method public static constructor-impl(Landroid/os/Bundle;)Landroid/os/Bundle;
    .locals 1

    .line 0
    const-string v0, "source"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    return-object p0
.end method

.method public static final contains-impl(Landroid/os/Bundle;Ljava/lang/String;)Z
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 790
    invoke-virtual {p0, p1}, Landroid/os/BaseBundle;->containsKey(Ljava/lang/String;)Z

    move-result p0

    return p0
.end method

.method public static final getBinder-impl(Landroid/os/Bundle;Ljava/lang/String;)Landroid/os/IBinder;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 57
    invoke-virtual {p0, p1}, Landroid/os/Bundle;->getBinder(Ljava/lang/String;)Landroid/os/IBinder;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getBoolean-impl(Landroid/os/Bundle;Ljava/lang/String;)Z
    .locals 2

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    .line 75
    invoke-virtual {p0, p1, v0}, Landroid/os/BaseBundle;->getBoolean(Ljava/lang/String;Z)Z

    move-result v0

    if-nez v0, :cond_1

    const/4 v1, 0x1

    .line 77
    invoke-virtual {p0, p1, v1}, Landroid/os/BaseBundle;->getBoolean(Ljava/lang/String;Z)Z

    move-result p0

    if-eq p0, v1, :cond_0

    goto :goto_0

    .line 79
    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0

    :cond_1
    :goto_0
    return v0
.end method

.method public static final getBooleanArray-impl(Landroid/os/Bundle;Ljava/lang/String;)[Z
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 549
    invoke-virtual {p0, p1}, Landroid/os/BaseBundle;->getBooleanArray(Ljava/lang/String;)[Z

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getChar-impl(Landroid/os/Bundle;Ljava/lang/String;)C
    .locals 2

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    .line 98
    invoke-virtual {p0, p1, v0}, Landroid/os/Bundle;->getChar(Ljava/lang/String;C)C

    move-result v0

    if-nez v0, :cond_1

    const v1, 0xffff

    .line 100
    invoke-virtual {p0, p1, v1}, Landroid/os/Bundle;->getChar(Ljava/lang/String;C)C

    move-result p0

    if-eq p0, v1, :cond_0

    goto :goto_0

    .line 102
    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0

    :cond_1
    :goto_0
    return v0
.end method

.method public static final getCharArray-impl(Landroid/os/Bundle;Ljava/lang/String;)[C
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 557
    invoke-virtual {p0, p1}, Landroid/os/Bundle;->getCharArray(Ljava/lang/String;)[C

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getCharSequence-impl(Landroid/os/Bundle;Ljava/lang/String;)Ljava/lang/CharSequence;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 120
    invoke-virtual {p0, p1}, Landroid/os/Bundle;->getCharSequence(Ljava/lang/String;)Ljava/lang/CharSequence;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getCharSequenceArray-impl(Landroid/os/Bundle;Ljava/lang/String;)[Ljava/lang/CharSequence;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 566
    invoke-virtual {p0, p1}, Landroid/os/Bundle;->getCharSequenceArray(Ljava/lang/String;)[Ljava/lang/CharSequence;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getCharSequenceList-impl(Landroid/os/Bundle;Ljava/lang/String;)Ljava/util/List;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 447
    invoke-virtual {p0, p1}, Landroid/os/Bundle;->getCharSequenceArrayList(Ljava/lang/String;)Ljava/util/ArrayList;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getDouble-impl(Landroid/os/Bundle;Ljava/lang/String;)D
    .locals 6

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-wide/16 v0, 0x1

    .line 128
    invoke-virtual {p0, p1, v0, v1}, Landroid/os/BaseBundle;->getDouble(Ljava/lang/String;D)D

    move-result-wide v2

    cmpg-double v0, v2, v0

    if-nez v0, :cond_1

    const-wide v0, 0x7fefffffffffffffL    # Double.MAX_VALUE

    .line 130
    invoke-virtual {p0, p1, v0, v1}, Landroid/os/BaseBundle;->getDouble(Ljava/lang/String;D)D

    move-result-wide v4

    cmpg-double p0, v4, v0

    if-eqz p0, :cond_0

    return-wide v2

    .line 132
    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0

    :cond_1
    return-wide v2
.end method

.method public static final getDoubleArray-impl(Landroid/os/Bundle;Ljava/lang/String;)[D
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 575
    invoke-virtual {p0, p1}, Landroid/os/BaseBundle;->getDoubleArray(Ljava/lang/String;)[D

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getFloat-impl(Landroid/os/Bundle;Ljava/lang/String;)F
    .locals 2

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x1

    .line 151
    invoke-virtual {p0, p1, v0}, Landroid/os/Bundle;->getFloat(Ljava/lang/String;F)F

    move-result v1

    cmpg-float v0, v1, v0

    if-nez v0, :cond_1

    const v0, 0x7f7fffff    # Float.MAX_VALUE

    .line 153
    invoke-virtual {p0, p1, v0}, Landroid/os/Bundle;->getFloat(Ljava/lang/String;F)F

    move-result p0

    cmpg-float p0, p0, v0

    if-eqz p0, :cond_0

    return v1

    .line 155
    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0

    :cond_1
    return v1
.end method

.method public static final getFloatArray-impl(Landroid/os/Bundle;Ljava/lang/String;)[F
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 583
    invoke-virtual {p0, p1}, Landroid/os/Bundle;->getFloatArray(Ljava/lang/String;)[F

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getInt-impl(Landroid/os/Bundle;Ljava/lang/String;)I
    .locals 2

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/high16 v0, -0x80000000

    .line 174
    invoke-virtual {p0, p1, v0}, Landroid/os/BaseBundle;->getInt(Ljava/lang/String;I)I

    move-result v1

    if-ne v1, v0, :cond_1

    const v0, 0x7fffffff

    .line 176
    invoke-virtual {p0, p1, v0}, Landroid/os/BaseBundle;->getInt(Ljava/lang/String;I)I

    move-result p0

    if-eq p0, v0, :cond_0

    goto :goto_0

    .line 178
    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0

    :cond_1
    :goto_0
    return v1
.end method

.method public static final getIntArray-impl(Landroid/os/Bundle;Ljava/lang/String;)[I
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 591
    invoke-virtual {p0, p1}, Landroid/os/BaseBundle;->getIntArray(Ljava/lang/String;)[I

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getIntList-impl(Landroid/os/Bundle;Ljava/lang/String;)Ljava/util/List;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 438
    invoke-virtual {p0, p1}, Landroid/os/Bundle;->getIntegerArrayList(Ljava/lang/String;)Ljava/util/ArrayList;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getJavaSerializable-impl(Landroid/os/Bundle;Ljava/lang/String;Lkotlin/reflect/KClass;)Ljava/io/Serializable;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "serializableClass"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 303
    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/jvm/JvmClassMappingKt;->getJavaClass(Lkotlin/reflect/KClass;)Ljava/lang/Class;

    move-result-object p2

    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/core/os/BundleCompat;->getSerializable(Landroid/os/Bundle;Ljava/lang/String;Ljava/lang/Class;)Ljava/io/Serializable;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getLong-impl(Landroid/os/Bundle;Ljava/lang/String;)J
    .locals 6

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-wide/high16 v0, -0x8000000000000000L

    .line 197
    invoke-virtual {p0, p1, v0, v1}, Landroid/os/BaseBundle;->getLong(Ljava/lang/String;J)J

    move-result-wide v2

    cmp-long v0, v2, v0

    if-nez v0, :cond_1

    const-wide v0, 0x7fffffffffffffffL

    .line 199
    invoke-virtual {p0, p1, v0, v1}, Landroid/os/BaseBundle;->getLong(Ljava/lang/String;J)J

    move-result-wide v4

    cmp-long p0, v4, v0

    if-eqz p0, :cond_0

    goto :goto_0

    .line 201
    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0

    :cond_1
    :goto_0
    return-wide v2
.end method

.method public static final getLongArray-impl(Landroid/os/Bundle;Ljava/lang/String;)[J
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 599
    invoke-virtual {p0, p1}, Landroid/os/BaseBundle;->getLongArray(Ljava/lang/String;)[J

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getParcelable-impl(Landroid/os/Bundle;Ljava/lang/String;Lkotlin/reflect/KClass;)Landroid/os/Parcelable;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "parcelableClass"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 234
    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/jvm/JvmClassMappingKt;->getJavaClass(Lkotlin/reflect/KClass;)Ljava/lang/Class;

    move-result-object p2

    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/core/os/BundleCompat;->getParcelable(Landroid/os/Bundle;Ljava/lang/String;Ljava/lang/Class;)Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Landroid/os/Parcelable;

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getParcelableArray-impl(Landroid/os/Bundle;Ljava/lang/String;Lkotlin/reflect/KClass;)[Landroid/os/Parcelable;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "parcelableClass"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 634
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getParcelableArrayOrNull-impl(Landroid/os/Bundle;Ljava/lang/String;Lkotlin/reflect/KClass;)[Landroid/os/Parcelable;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getParcelableArrayOrNull-impl(Landroid/os/Bundle;Ljava/lang/String;Lkotlin/reflect/KClass;)[Landroid/os/Parcelable;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "parcelableClass"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 673
    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/jvm/JvmClassMappingKt;->getJavaClass(Lkotlin/reflect/KClass;)Ljava/lang/Class;

    move-result-object p2

    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/core/os/BundleCompat;->getParcelableArray(Landroid/os/Bundle;Ljava/lang/String;Ljava/lang/Class;)[Landroid/os/Parcelable;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    const/4 p0, 0x0

    return-object p0
.end method

.method public static final getParcelableList-impl(Landroid/os/Bundle;Ljava/lang/String;Lkotlin/reflect/KClass;)Ljava/util/List;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "parcelableClass"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 491
    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/jvm/JvmClassMappingKt;->getJavaClass(Lkotlin/reflect/KClass;)Ljava/lang/Class;

    move-result-object p2

    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/core/os/BundleCompat;->getParcelableArrayList(Landroid/os/Bundle;Ljava/lang/String;Ljava/lang/Class;)Ljava/util/ArrayList;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    .line 492
    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getSavedState-impl(Landroid/os/Bundle;Ljava/lang/String;)Landroid/os/Bundle;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 771
    invoke-virtual {p0, p1}, Landroid/os/Bundle;->getBundle(Ljava/lang/String;)Landroid/os/Bundle;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getSavedStateOrNull-impl(Landroid/os/Bundle;Ljava/lang/String;)Landroid/os/Bundle;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 776
    invoke-virtual {p0, p1}, Landroid/os/Bundle;->getBundle(Ljava/lang/String;)Landroid/os/Bundle;

    move-result-object p0

    return-object p0
.end method

.method public static final getSize-impl(Landroid/os/Bundle;Ljava/lang/String;)Landroid/util/Size;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 371
    invoke-virtual {p0, p1}, Landroid/os/Bundle;->getSize(Ljava/lang/String;)Landroid/util/Size;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getSizeF-impl(Landroid/os/Bundle;Ljava/lang/String;)Landroid/util/SizeF;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 402
    invoke-virtual {p0, p1}, Landroid/os/Bundle;->getSizeF(Ljava/lang/String;)Landroid/util/SizeF;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getSparseParcelableArray-impl(Landroid/os/Bundle;Ljava/lang/String;Lkotlin/reflect/KClass;)Landroid/util/SparseArray;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "parcelableClass"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 711
    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->getSparseParcelableArrayOrNull-impl(Landroid/os/Bundle;Ljava/lang/String;Lkotlin/reflect/KClass;)Landroid/util/SparseArray;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getSparseParcelableArrayOrNull-impl(Landroid/os/Bundle;Ljava/lang/String;Lkotlin/reflect/KClass;)Landroid/util/SparseArray;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "parcelableClass"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 750
    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/kotlin/jvm/JvmClassMappingKt;->getJavaClass(Lkotlin/reflect/KClass;)Ljava/lang/Class;

    move-result-object p2

    invoke-static {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/core/os/BundleCompat;->getSparseParcelableArray(Landroid/os/Bundle;Ljava/lang/String;Ljava/lang/Class;)Landroid/util/SparseArray;

    move-result-object p0

    return-object p0
.end method

.method public static final getString-impl(Landroid/os/Bundle;Ljava/lang/String;)Ljava/lang/String;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 430
    invoke-virtual {p0, p1}, Landroid/os/BaseBundle;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getStringArray-impl(Landroid/os/Bundle;Ljava/lang/String;)[Ljava/lang/String;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 607
    invoke-virtual {p0, p1}, Landroid/os/BaseBundle;->getStringArray(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getStringList-impl(Landroid/os/Bundle;Ljava/lang/String;)Ljava/util/List;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 465
    invoke-virtual {p0, p1}, Landroid/os/Bundle;->getStringArrayList(Ljava/lang/String;)Ljava/util/ArrayList;

    move-result-object p0

    if-eqz p0, :cond_0

    return-object p0

    :cond_0
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReaderKt;->keyOrValueNotFoundError(Ljava/lang/String;)Ljava/lang/Void;

    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/KotlinNothingValueException;-><init>()V

    throw p0
.end method

.method public static final getStringListOrNull-impl(Landroid/os/Bundle;Ljava/lang/String;)Ljava/util/List;
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 470
    invoke-virtual {p0, p1}, Landroid/os/Bundle;->getStringArrayList(Ljava/lang/String;)Ljava/util/ArrayList;

    move-result-object p0

    return-object p0
.end method

.method public static final isEmpty-impl(Landroid/os/Bundle;)Z
    .locals 0

    .line 781
    invoke-virtual {p0}, Landroid/os/BaseBundle;->isEmpty()Z

    move-result p0

    return p0
.end method

.method public static final isNull-impl(Landroid/os/Bundle;Ljava/lang/String;)Z
    .locals 1

    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 787
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/SavedStateReader;->contains-impl(Landroid/os/Bundle;Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-virtual {p0, p1}, Landroid/os/BaseBundle;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object p0

    if-nez p0, :cond_0

    const/4 p0, 0x1

    return p0

    :cond_0
    const/4 p0, 0x0

    return p0
.end method

.method public static final size-impl(Landroid/os/Bundle;)I
    .locals 0

    .line 779
    invoke-virtual {p0}, Landroid/os/BaseBundle;->size()I

    move-result p0

    return p0
.end method

.method public static final toMap-impl(Landroid/os/Bundle;)Ljava/util/Map;
    .locals 4

    .line 804
    invoke-virtual {p0}, Landroid/os/BaseBundle;->size()I

    move-result v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/MapsKt;->createMapBuilder(I)Ljava/util/Map;

    move-result-object v0

    .line 805
    invoke-virtual {p0}, Landroid/os/BaseBundle;->keySet()Ljava/util/Set;

    move-result-object v1

    invoke-interface {v1}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_0

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    .line 806
    invoke-static {v2}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;)V

    invoke-virtual {p0, v2}, Landroid/os/BaseBundle;->get(Ljava/lang/String;)Ljava/lang/Object;

    move-result-object v3

    invoke-interface {v0, v2, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_0

    .line 804
    :cond_0
    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/MapsKt;->build(Ljava/util/Map;)Ljava/util/Map;

    move-result-object p0

    return-object p0
.end method
