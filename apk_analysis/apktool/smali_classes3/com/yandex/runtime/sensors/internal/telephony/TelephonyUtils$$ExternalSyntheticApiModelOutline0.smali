.class public abstract synthetic Lcom/yandex/runtime/sensors/internal/telephony/TelephonyUtils$$ExternalSyntheticApiModelOutline0;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"


# direct methods
.method public static bridge synthetic m(Landroid/telephony/CellInfo;)J
    .locals 2

    .line 0
    invoke-virtual {p0}, Landroid/telephony/CellInfo;->getTimestampMillis()J

    move-result-wide v0

    return-wide v0
.end method
