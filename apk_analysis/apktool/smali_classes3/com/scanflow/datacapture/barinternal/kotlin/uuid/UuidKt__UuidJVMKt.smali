.class abstract Lcom/scanflow/datacapture/barinternal/kotlin/uuid/UuidKt__UuidJVMKt;
.super Ljava/lang/Object;
.source "UuidJVM.kt"


# direct methods
.method public static final formatBytesInto(J[BIII)V
    .locals 1

    const-string v0, "dst"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 59
    invoke-static/range {p0 .. p5}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/UuidKt__UuidKt;->formatBytesIntoCommonImpl(J[BIII)V

    return-void
.end method

.method public static final uuidParseHex(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;
    .locals 1

    const-string v0, "hexString"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 75
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/UuidKt__UuidKt;->uuidParseHexCommonImpl(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;

    move-result-object p0

    return-object p0
.end method

.method public static final uuidParseHexDash(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;
    .locals 1

    const-string v0, "hexDashString"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 67
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/UuidKt__UuidKt;->uuidParseHexDashCommonImpl(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;

    move-result-object p0

    return-object p0
.end method
