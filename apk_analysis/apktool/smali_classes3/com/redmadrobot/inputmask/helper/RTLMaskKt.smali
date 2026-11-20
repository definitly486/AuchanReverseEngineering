.class public final Lcom/redmadrobot/inputmask/helper/RTLMaskKt;
.super Ljava/lang/Object;
.source "RTLMask.kt"


# direct methods
.method public static final synthetic access$reversedFormat(Ljava/lang/String;)Ljava/lang/String;
    .locals 0

    .line 1
    invoke-static {p0}, Lcom/redmadrobot/inputmask/helper/RTLMaskKt;->reversedFormat(Ljava/lang/String;)Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method

.method private static final reversedFormat(Ljava/lang/String;)Ljava/lang/String;
    .locals 12

    if-eqz p0, :cond_3

    .line 37
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->reversed(Ljava/lang/CharSequence;)Ljava/lang/CharSequence;

    move-result-object p0

    invoke-virtual {p0}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v0

    const/4 v4, 0x4

    const/4 v5, 0x0

    .line 38
    const-string v1, "[\\"

    const-string v2, "\\]"

    const/4 v3, 0x0

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v6

    const/4 v10, 0x4

    const/4 v11, 0x0

    .line 39
    const-string v7, "]\\"

    const-string v8, "\\["

    const/4 v9, 0x0

    invoke-static/range {v6 .. v11}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    .line 40
    const-string v1, "{\\"

    const-string v2, "\\}"

    invoke-static/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v6

    .line 41
    const-string v7, "}\\"

    const-string v8, "\\{"

    invoke-static/range {v6 .. v11}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object p0

    .line 52
    new-instance v0, Ljava/util/ArrayList;

    invoke-interface {p0}, Ljava/lang/CharSequence;->length()I

    move-result v1

    invoke-direct {v0, v1}, Ljava/util/ArrayList;-><init>(I)V

    const/4 v1, 0x0

    .line 889
    :goto_0
    invoke-interface {p0}, Ljava/lang/CharSequence;->length()I

    move-result v2

    if-ge v1, v2, :cond_2

    invoke-interface {p0, v1}, Ljava/lang/CharSequence;->charAt(I)C

    move-result v2

    const/16 v3, 0x5d

    const/16 v4, 0x5b

    if-eq v2, v4, :cond_1

    if-eq v2, v3, :cond_0

    const/16 v3, 0x7d

    const/16 v4, 0x7b

    if-eq v2, v4, :cond_1

    if-eq v2, v3, :cond_0

    goto :goto_1

    :cond_0
    move v2, v4

    goto :goto_1

    :cond_1
    move v2, v3

    .line 49
    :goto_1
    invoke-static {v2}, Ljava/lang/Character;->valueOf(C)Ljava/lang/Character;

    move-result-object v2

    invoke-interface {v0, v2}, Ljava/util/Collection;->add(Ljava/lang/Object;)Z

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    :cond_2
    const/16 v7, 0x3e

    const/4 v8, 0x0

    .line 50
    const-string v1, ""

    const/4 v2, 0x0

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    const/4 v6, 0x0

    invoke-static/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->joinToString$default(Ljava/lang/Iterable;Ljava/lang/CharSequence;Ljava/lang/CharSequence;Ljava/lang/CharSequence;ILjava/lang/CharSequence;Lkotlin/jvm/functions/Function1;ILjava/lang/Object;)Ljava/lang/String;

    move-result-object p0

    return-object p0

    .line 37
    :cond_3
    new-instance p0, Lcom/scanflow/datacapture/barinternal/kotlin/TypeCastException;

    const-string v0, "null cannot be cast to non-null type kotlin.CharSequence"

    invoke-direct {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/TypeCastException;-><init>(Ljava/lang/String;)V

    throw p0
.end method
