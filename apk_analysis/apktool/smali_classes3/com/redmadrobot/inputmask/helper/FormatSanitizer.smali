.class public final Lcom/redmadrobot/inputmask/helper/FormatSanitizer;
.super Ljava/lang/Object;
.source "FormatSanitizer.kt"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 23
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private final checkOpenBraces(Ljava/lang/String;)V
    .locals 8

    if-eqz p1, :cond_8

    .line 209
    invoke-virtual {p1}, Ljava/lang/String;->toCharArray()[C

    move-result-object p1

    const-string v0, "(this as java.lang.String).toCharArray()"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkExpressionValueIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    array-length v0, p1

    const/4 v1, 0x0

    move v2, v1

    move v3, v2

    move v4, v3

    move v5, v4

    :goto_0
    if-ge v2, v0, :cond_7

    aget-char v6, p1, v2

    const/16 v7, 0x5c

    if-ne v7, v6, :cond_0

    xor-int/lit8 v3, v3, 0x1

    goto :goto_3

    :cond_0
    const/16 v7, 0x5b

    if-ne v7, v6, :cond_2

    if-nez v4, :cond_1

    xor-int/lit8 v4, v3, 0x1

    goto :goto_1

    .line 217
    :cond_1
    new-instance p1, Lcom/redmadrobot/inputmask/helper/Compiler$FormatError;

    invoke-direct {p1}, Lcom/redmadrobot/inputmask/helper/Compiler$FormatError;-><init>()V

    throw p1

    :cond_2
    :goto_1
    const/16 v7, 0x5d

    if-ne v7, v6, :cond_3

    if-nez v3, :cond_3

    move v4, v1

    :cond_3
    const/16 v7, 0x7b

    if-ne v7, v6, :cond_5

    if-nez v5, :cond_4

    xor-int/lit8 v5, v3, 0x1

    goto :goto_2

    .line 228
    :cond_4
    new-instance p1, Lcom/redmadrobot/inputmask/helper/Compiler$FormatError;

    invoke-direct {p1}, Lcom/redmadrobot/inputmask/helper/Compiler$FormatError;-><init>()V

    throw p1

    :cond_5
    :goto_2
    const/16 v7, 0x7d

    if-ne v7, v6, :cond_6

    if-nez v3, :cond_6

    move v5, v1

    :cond_6
    move v3, v1

    :goto_3
    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_7
    return-void

    .line 209
    :cond_8
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/TypeCastException;

    const-string v0, "null cannot be cast to non-null type java.lang.String"

    invoke-direct {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/TypeCastException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method private final divideBlocksWithMixedCharacters(Ljava/util/List;)Ljava/util/List;
    .locals 18
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 108
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    .line 110
    invoke-interface/range {p1 .. p1}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_e

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    .line 111
    const-string v3, "["

    const/4 v4, 0x0

    const/4 v5, 0x2

    const/4 v6, 0x0

    invoke-static {v2, v3, v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->startsWith$default(Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_d

    .line 113
    invoke-virtual {v2}, Ljava/lang/String;->length()I

    move-result v3

    const-string v7, ""

    move v8, v4

    :goto_1
    if-ge v8, v3, :cond_1

    invoke-virtual {v2, v8}, Ljava/lang/String;->charAt(I)C

    move-result v9

    const/16 v10, 0x5b

    if-ne v9, v10, :cond_0

    .line 115
    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v10, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v10, v9}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    move-object/from16 v16, v1

    move v1, v4

    move v11, v5

    goto/16 :goto_8

    :cond_0
    const/16 v11, 0x5d

    if-ne v9, v11, :cond_2

    .line 119
    const-string v11, "\\"

    invoke-static {v7, v11, v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->endsWith$default(Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Z

    move-result v11

    if-nez v11, :cond_2

    .line 120
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v2, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v9}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    .line 121
    invoke-interface {v0, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    :cond_1
    move-object/from16 v16, v1

    goto/16 :goto_9

    :cond_2
    const/16 v11, 0x30

    .line 125
    const-string v12, "_"

    const-string v13, "-"

    const-string v14, "a"

    const-string v15, "A"

    const-string v10, "]"

    if-eq v9, v11, :cond_3

    const/16 v11, 0x39

    if-ne v9, v11, :cond_5

    .line 126
    :cond_3
    invoke-static {v7, v15, v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v11

    if-nez v11, :cond_4

    .line 127
    invoke-static {v7, v14, v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v11

    if-nez v11, :cond_4

    .line 128
    invoke-static {v7, v13, v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v11

    if-nez v11, :cond_4

    .line 129
    invoke-static {v7, v12, v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v11

    if-eqz v11, :cond_5

    :cond_4
    move-object/from16 v16, v1

    move v1, v4

    move v11, v5

    goto/16 :goto_7

    :cond_5
    const/16 v11, 0x41

    .line 138
    const-string v4, "9"

    const-string v5, "0"

    if-eq v9, v11, :cond_6

    const/16 v11, 0x61

    if-ne v9, v11, :cond_7

    :cond_6
    move-object/from16 v16, v1

    const/4 v1, 0x0

    const/4 v11, 0x2

    goto :goto_2

    :cond_7
    move-object/from16 v16, v1

    const/4 v1, 0x0

    const/4 v11, 0x2

    goto :goto_3

    .line 139
    :goto_2
    invoke-static {v7, v5, v1, v11, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v17

    if-nez v17, :cond_c

    .line 140
    invoke-static {v7, v4, v1, v11, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v17

    if-nez v17, :cond_c

    .line 141
    invoke-static {v7, v13, v1, v11, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v13

    if-nez v13, :cond_c

    .line 142
    invoke-static {v7, v12, v1, v11, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v12

    if-eqz v12, :cond_8

    goto :goto_6

    :cond_8
    :goto_3
    const/16 v12, 0x2d

    if-eq v9, v12, :cond_9

    const/16 v12, 0x5f

    if-ne v9, v12, :cond_a

    .line 152
    :cond_9
    invoke-static {v7, v5, v1, v11, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v5

    if-nez v5, :cond_b

    .line 153
    invoke-static {v7, v4, v1, v11, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_b

    .line 154
    invoke-static {v7, v15, v1, v11, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_b

    .line 155
    invoke-static {v7, v14, v1, v11, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_a

    goto :goto_5

    .line 164
    :cond_a
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v4, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v9}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    :goto_4
    move-object v7, v4

    goto :goto_8

    .line 157
    :cond_b
    :goto_5
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v4, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    .line 158
    invoke-interface {v0, v4}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 159
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const/16 v5, 0x5b

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v9}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    goto :goto_4

    .line 144
    :cond_c
    :goto_6
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v4, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    .line 145
    invoke-interface {v0, v4}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 146
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const/16 v5, 0x5b

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v9}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    goto :goto_4

    .line 131
    :goto_7
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v4, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    .line 132
    invoke-interface {v0, v4}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 133
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const/16 v5, 0x5b

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v4, v9}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    goto :goto_4

    :goto_8
    add-int/lit8 v8, v8, 0x1

    move v4, v1

    move v5, v11

    move-object/from16 v1, v16

    goto/16 :goto_1

    :cond_d
    move-object/from16 v16, v1

    .line 167
    invoke-interface {v0, v2}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    :goto_9
    move-object/from16 v1, v16

    goto/16 :goto_0

    :cond_e
    return-object v0
.end method

.method private final getFormatBlocks(Ljava/lang/String;)Ljava/util/List;
    .locals 9
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            ")",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 70
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    if-eqz p1, :cond_8

    .line 74
    invoke-virtual {p1}, Ljava/lang/String;->toCharArray()[C

    move-result-object p1

    const-string v1, "(this as java.lang.String).toCharArray()"

    invoke-static {p1, v1}, Lkotlin/jvm/internal/Intrinsics;->checkExpressionValueIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    array-length v1, p1

    const-string v2, ""

    const/4 v3, 0x0

    move-object v5, v2

    move v4, v3

    move v6, v4

    :goto_0
    if-ge v4, v1, :cond_6

    aget-char v7, p1, v4

    const/16 v8, 0x5c

    if-ne v8, v7, :cond_0

    if-nez v6, :cond_0

    .line 78
    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v6, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v6, v7}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    const/4 v6, 0x1

    goto :goto_1

    :cond_0
    const/16 v8, 0x5b

    if-eq v8, v7, :cond_1

    const/16 v8, 0x7b

    if-ne v8, v7, :cond_3

    :cond_1
    if-nez v6, :cond_3

    .line 84
    invoke-interface {v5}, Ljava/lang/CharSequence;->length()I

    move-result v8

    if-lez v8, :cond_2

    .line 85
    invoke-interface {v0, v5}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    :cond_2
    move-object v5, v2

    .line 90
    :cond_3
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v8, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v8, v7}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    const/16 v8, 0x5d

    if-eq v8, v7, :cond_4

    const/16 v8, 0x7d

    if-ne v8, v7, :cond_5

    :cond_4
    if-nez v6, :cond_5

    .line 93
    invoke-interface {v0, v5}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    move-object v5, v2

    :cond_5
    move v6, v3

    :goto_1
    add-int/lit8 v4, v4, 0x1

    goto :goto_0

    .line 100
    :cond_6
    invoke-interface {v5}, Ljava/lang/CharSequence;->length()I

    move-result p1

    if-nez p1, :cond_7

    return-object v0

    .line 101
    :cond_7
    invoke-interface {v0, v5}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    return-object v0

    .line 74
    :cond_8
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/TypeCastException;

    const-string v0, "null cannot be cast to non-null type java.lang.String"

    invoke-direct {p1, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/TypeCastException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method private final sortFormatBlocks(Ljava/util/List;)Ljava/util/List;
    .locals 22
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 176
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    .line 178
    invoke-interface/range {p1 .. p1}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v2

    if-eqz v2, :cond_8

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v2

    move-object v3, v2

    check-cast v3, Ljava/lang/String;

    .line 180
    const-string v2, "["

    const/4 v4, 0x0

    const/4 v5, 0x2

    const/4 v6, 0x0

    invoke-static {v3, v2, v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->startsWith$default(Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Z

    move-result v7

    if-eqz v7, :cond_7

    .line 181
    const-string v7, "0"

    invoke-static {v3, v7, v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v7

    const-string v9, "]"

    const-string v10, "(this as java.lang.String).toCharArray()"

    const-string v11, "null cannot be cast to non-null type java.lang.String"

    if-nez v7, :cond_5

    const-string v7, "9"

    invoke-static {v3, v7, v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v7

    if-eqz v7, :cond_0

    goto/16 :goto_2

    .line 184
    :cond_0
    const-string v7, "a"

    invoke-static {v3, v7, v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_3

    const-string v7, "A"

    invoke-static {v3, v7, v4, v5, v6}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->contains$default(Ljava/lang/CharSequence;Ljava/lang/CharSequence;ZILjava/lang/Object;)Z

    move-result v4

    if-eqz v4, :cond_1

    goto/16 :goto_1

    .line 188
    :cond_1
    new-instance v12, Ljava/lang/StringBuilder;

    invoke-direct {v12}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v12, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/4 v7, 0x4

    const/4 v8, 0x0

    const-string v4, "["

    const-string v5, ""

    const/4 v6, 0x0

    invoke-static/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v13

    const/16 v17, 0x4

    const/16 v18, 0x0

    const-string v14, "]"

    const-string v15, ""

    const/16 v16, 0x0

    invoke-static/range {v13 .. v18}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    const/4 v6, 0x4

    const/4 v7, 0x0

    const-string v3, "_"

    const-string v4, "A"

    const/4 v5, 0x0

    invoke-static/range {v2 .. v7}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v13

    const-string v14, "-"

    const-string v15, "a"

    invoke-static/range {v13 .. v18}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    if-eqz v2, :cond_2

    .line 191
    invoke-virtual {v2}, Ljava/lang/String;->toCharArray()[C

    move-result-object v2

    invoke-static {v2, v10}, Lkotlin/jvm/internal/Intrinsics;->checkExpressionValueIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->sorted([C)Ljava/util/List;

    move-result-object v2

    move-object v13, v2

    check-cast v13, Ljava/lang/Iterable;

    const/16 v20, 0x3e

    const/16 v21, 0x0

    const-string v14, ""

    const/4 v15, 0x0

    const/16 v16, 0x0

    const/16 v17, 0x0

    const/16 v18, 0x0

    const/16 v19, 0x0

    invoke-static/range {v13 .. v21}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->joinToString$default(Ljava/lang/Iterable;Ljava/lang/CharSequence;Ljava/lang/CharSequence;Ljava/lang/CharSequence;ILjava/lang/CharSequence;Lkotlin/jvm/functions/Function1;ILjava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v12, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v12, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v12}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    const/4 v7, 0x4

    const/4 v8, 0x0

    .line 192
    const-string v4, "A"

    const-string v5, "_"

    const/4 v6, 0x0

    invoke-static/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v9

    const/4 v13, 0x4

    const/4 v14, 0x0

    const-string v10, "a"

    const-string v11, "-"

    const/4 v12, 0x0

    invoke-static/range {v9 .. v14}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v3

    goto/16 :goto_3

    .line 191
    :cond_2
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/TypeCastException;

    invoke-direct {v0, v11}, Lcom/scanflow/datacapture/barinternal/kotlin/TypeCastException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 186
    :cond_3
    :goto_1
    new-instance v12, Ljava/lang/StringBuilder;

    invoke-direct {v12}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v12, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/4 v7, 0x4

    const/4 v8, 0x0

    const-string v4, "["

    const-string v5, ""

    const/4 v6, 0x0

    invoke-static/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v13

    const/16 v17, 0x4

    const/16 v18, 0x0

    const-string v14, "]"

    const-string v15, ""

    const/16 v16, 0x0

    invoke-static/range {v13 .. v18}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    if-eqz v2, :cond_4

    invoke-virtual {v2}, Ljava/lang/String;->toCharArray()[C

    move-result-object v2

    invoke-static {v2, v10}, Lkotlin/jvm/internal/Intrinsics;->checkExpressionValueIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->sorted([C)Ljava/util/List;

    move-result-object v2

    move-object v13, v2

    check-cast v13, Ljava/lang/Iterable;

    const/16 v20, 0x3e

    const/16 v21, 0x0

    const-string v14, ""

    const/4 v15, 0x0

    const/16 v16, 0x0

    const/16 v17, 0x0

    const/16 v18, 0x0

    const/16 v19, 0x0

    invoke-static/range {v13 .. v21}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->joinToString$default(Ljava/lang/Iterable;Ljava/lang/CharSequence;Ljava/lang/CharSequence;Ljava/lang/CharSequence;ILjava/lang/CharSequence;Lkotlin/jvm/functions/Function1;ILjava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v12, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v12, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v12}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    goto :goto_3

    :cond_4
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/TypeCastException;

    invoke-direct {v0, v11}, Lcom/scanflow/datacapture/barinternal/kotlin/TypeCastException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 183
    :cond_5
    :goto_2
    new-instance v12, Ljava/lang/StringBuilder;

    invoke-direct {v12}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v12, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/4 v7, 0x4

    const/4 v8, 0x0

    const-string v4, "["

    const-string v5, ""

    const/4 v6, 0x0

    invoke-static/range {v3 .. v8}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v13

    const/16 v17, 0x4

    const/16 v18, 0x0

    const-string v14, "]"

    const-string v15, ""

    const/16 v16, 0x0

    invoke-static/range {v13 .. v18}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->replace$default(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ZILjava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    if-eqz v2, :cond_6

    invoke-virtual {v2}, Ljava/lang/String;->toCharArray()[C

    move-result-object v2

    invoke-static {v2, v10}, Lkotlin/jvm/internal/Intrinsics;->checkExpressionValueIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/ArraysKt;->sorted([C)Ljava/util/List;

    move-result-object v2

    move-object v13, v2

    check-cast v13, Ljava/lang/Iterable;

    const/16 v20, 0x3e

    const/16 v21, 0x0

    const-string v14, ""

    const/4 v15, 0x0

    const/16 v16, 0x0

    const/16 v17, 0x0

    const/16 v18, 0x0

    const/16 v19, 0x0

    invoke-static/range {v13 .. v21}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->joinToString$default(Ljava/lang/Iterable;Ljava/lang/CharSequence;Ljava/lang/CharSequence;Ljava/lang/CharSequence;ILjava/lang/CharSequence;Lkotlin/jvm/functions/Function1;ILjava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v12, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v12, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v12}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    goto :goto_3

    :cond_6
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/TypeCastException;

    invoke-direct {v0, v11}, Lcom/scanflow/datacapture/barinternal/kotlin/TypeCastException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 198
    :cond_7
    :goto_3
    invoke-interface {v0, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto/16 :goto_0

    :cond_8
    return-object v0
.end method


# virtual methods
.method public final sanitize(Ljava/lang/String;)Ljava/lang/String;
    .locals 9

    const-string v0, "formatString"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 61
    invoke-direct {p0, p1}, Lcom/redmadrobot/inputmask/helper/FormatSanitizer;->checkOpenBraces(Ljava/lang/String;)V

    .line 64
    invoke-direct {p0, p1}, Lcom/redmadrobot/inputmask/helper/FormatSanitizer;->getFormatBlocks(Ljava/lang/String;)Ljava/util/List;

    move-result-object p1

    invoke-direct {p0, p1}, Lcom/redmadrobot/inputmask/helper/FormatSanitizer;->divideBlocksWithMixedCharacters(Ljava/util/List;)Ljava/util/List;

    move-result-object p1

    .line 66
    invoke-direct {p0, p1}, Lcom/redmadrobot/inputmask/helper/FormatSanitizer;->sortFormatBlocks(Ljava/util/List;)Ljava/util/List;

    move-result-object p1

    move-object v0, p1

    check-cast v0, Ljava/lang/Iterable;

    const/16 v7, 0x3e

    const/4 v8, 0x0

    const-string v1, ""

    const/4 v2, 0x0

    const/4 v3, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    const/4 v6, 0x0

    invoke-static/range {v0 .. v8}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->joinToString$default(Ljava/lang/Iterable;Ljava/lang/CharSequence;Ljava/lang/CharSequence;Ljava/lang/CharSequence;ILjava/lang/CharSequence;Lkotlin/jvm/functions/Function1;ILjava/lang/Object;)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method
