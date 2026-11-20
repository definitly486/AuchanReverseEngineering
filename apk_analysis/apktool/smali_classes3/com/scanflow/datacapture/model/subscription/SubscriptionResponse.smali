.class public final Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation build Landroidx/annotation/Keep;
.end annotation


# instance fields
.field private apikey:Ljava/lang/String;

.field private deviceInfo:Lcom/scanflow/datacapture/model/DeviceInfo;

.field private final message:Ljava/lang/String;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "message"
    .end annotation
.end field

.field private result:Lcom/scanflow/datacapture/model/subscription/Result;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "result"
    .end annotation
.end field

.field private final status:Ljava/lang/String;
    .annotation runtime Lcom/google/gson/annotations/SerializedName;
        value = "status"
    .end annotation
.end field


# direct methods
.method public constructor <init>(Ljava/lang/String;Lcom/scanflow/datacapture/model/subscription/Result;Ljava/lang/String;Lcom/scanflow/datacapture/model/DeviceInfo;Ljava/lang/String;)V
    .locals 1

    .line 0
    const-string v0, "message"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "status"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->message:Ljava/lang/String;

    iput-object p2, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->result:Lcom/scanflow/datacapture/model/subscription/Result;

    iput-object p3, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->status:Ljava/lang/String;

    iput-object p4, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->deviceInfo:Lcom/scanflow/datacapture/model/DeviceInfo;

    iput-object p5, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->apikey:Ljava/lang/String;

    return-void
.end method

.method public static synthetic copy$default(Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;Ljava/lang/String;Lcom/scanflow/datacapture/model/subscription/Result;Ljava/lang/String;Lcom/scanflow/datacapture/model/DeviceInfo;Ljava/lang/String;ILjava/lang/Object;)Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;
    .locals 0

    .line 0
    and-int/lit8 p7, p6, 0x1

    if-eqz p7, :cond_0

    iget-object p1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->message:Ljava/lang/String;

    :cond_0
    and-int/lit8 p7, p6, 0x2

    if-eqz p7, :cond_1

    iget-object p2, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->result:Lcom/scanflow/datacapture/model/subscription/Result;

    :cond_1
    and-int/lit8 p7, p6, 0x4

    if-eqz p7, :cond_2

    iget-object p3, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->status:Ljava/lang/String;

    :cond_2
    and-int/lit8 p7, p6, 0x8

    if-eqz p7, :cond_3

    iget-object p4, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->deviceInfo:Lcom/scanflow/datacapture/model/DeviceInfo;

    :cond_3
    and-int/lit8 p6, p6, 0x10

    if-eqz p6, :cond_4

    iget-object p5, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->apikey:Ljava/lang/String;

    :cond_4
    move-object p6, p4

    move-object p7, p5

    move-object p4, p2

    move-object p5, p3

    move-object p2, p0

    move-object p3, p1

    invoke-virtual/range {p2 .. p7}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->copy(Ljava/lang/String;Lcom/scanflow/datacapture/model/subscription/Result;Ljava/lang/String;Lcom/scanflow/datacapture/model/DeviceInfo;Ljava/lang/String;)Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public final component1()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->message:Ljava/lang/String;

    return-object v0
.end method

.method public final component2()Lcom/scanflow/datacapture/model/subscription/Result;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->result:Lcom/scanflow/datacapture/model/subscription/Result;

    return-object v0
.end method

.method public final component3()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->status:Ljava/lang/String;

    return-object v0
.end method

.method public final component4()Lcom/scanflow/datacapture/model/DeviceInfo;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->deviceInfo:Lcom/scanflow/datacapture/model/DeviceInfo;

    return-object v0
.end method

.method public final component5()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->apikey:Ljava/lang/String;

    return-object v0
.end method

.method public final copy(Ljava/lang/String;Lcom/scanflow/datacapture/model/subscription/Result;Ljava/lang/String;Lcom/scanflow/datacapture/model/DeviceInfo;Ljava/lang/String;)Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;
    .locals 7

    .line 0
    const-string v0, "message"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "status"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v1, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object v5, p4

    move-object v6, p5

    invoke-direct/range {v1 .. v6}, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;-><init>(Ljava/lang/String;Lcom/scanflow/datacapture/model/subscription/Result;Ljava/lang/String;Lcom/scanflow/datacapture/model/DeviceInfo;Ljava/lang/String;)V

    return-object v1
.end method

.method public equals(Ljava/lang/Object;)Z
    .locals 4

    .line 0
    const/4 v0, 0x1

    if-ne p0, p1, :cond_0

    return v0

    :cond_0
    instance-of v1, p1, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    const/4 v2, 0x0

    if-nez v1, :cond_1

    return v2

    :cond_1
    check-cast p1, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;

    iget-object v1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->message:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->message:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_2

    return v2

    :cond_2
    iget-object v1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->result:Lcom/scanflow/datacapture/model/subscription/Result;

    iget-object v3, p1, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->result:Lcom/scanflow/datacapture/model/subscription/Result;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_3

    return v2

    :cond_3
    iget-object v1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->status:Ljava/lang/String;

    iget-object v3, p1, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->status:Ljava/lang/String;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_4

    return v2

    :cond_4
    iget-object v1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->deviceInfo:Lcom/scanflow/datacapture/model/DeviceInfo;

    iget-object v3, p1, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->deviceInfo:Lcom/scanflow/datacapture/model/DeviceInfo;

    invoke-static {v1, v3}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_5

    return v2

    :cond_5
    iget-object v1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->apikey:Ljava/lang/String;

    iget-object p1, p1, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->apikey:Ljava/lang/String;

    invoke-static {v1, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-nez p1, :cond_6

    return v2

    :cond_6
    return v0
.end method

.method public final getApikey()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->apikey:Ljava/lang/String;

    return-object v0
.end method

.method public final getDeviceInfo()Lcom/scanflow/datacapture/model/DeviceInfo;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->deviceInfo:Lcom/scanflow/datacapture/model/DeviceInfo;

    return-object v0
.end method

.method public final getMessage()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->message:Ljava/lang/String;

    return-object v0
.end method

.method public final getResult()Lcom/scanflow/datacapture/model/subscription/Result;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->result:Lcom/scanflow/datacapture/model/subscription/Result;

    return-object v0
.end method

.method public final getStatus()Ljava/lang/String;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->status:Ljava/lang/String;

    return-object v0
.end method

.method public hashCode()I
    .locals 3

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->message:Ljava/lang/String;

    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v0

    mul-int/lit8 v0, v0, 0x1f

    iget-object v1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->result:Lcom/scanflow/datacapture/model/subscription/Result;

    const/4 v2, 0x0

    if-nez v1, :cond_0

    move v1, v2

    goto :goto_0

    :cond_0
    invoke-virtual {v1}, Lcom/scanflow/datacapture/model/subscription/Result;->hashCode()I

    move-result v1

    :goto_0
    add-int/2addr v0, v1

    mul-int/lit8 v0, v0, 0x1f

    iget-object v1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->status:Ljava/lang/String;

    invoke-virtual {v1}, Ljava/lang/String;->hashCode()I

    move-result v1

    add-int/2addr v1, v0

    mul-int/lit8 v1, v1, 0x1f

    iget-object v0, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->deviceInfo:Lcom/scanflow/datacapture/model/DeviceInfo;

    if-nez v0, :cond_1

    move v0, v2

    goto :goto_1

    :cond_1
    invoke-virtual {v0}, Lcom/scanflow/datacapture/model/DeviceInfo;->hashCode()I

    move-result v0

    :goto_1
    add-int/2addr v1, v0

    mul-int/lit8 v1, v1, 0x1f

    iget-object v0, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->apikey:Ljava/lang/String;

    if-nez v0, :cond_2

    goto :goto_2

    :cond_2
    invoke-virtual {v0}, Ljava/lang/String;->hashCode()I

    move-result v2

    :goto_2
    add-int/2addr v1, v2

    return v1
.end method

.method public final setApikey(Ljava/lang/String;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->apikey:Ljava/lang/String;

    return-void
.end method

.method public final setDeviceInfo(Lcom/scanflow/datacapture/model/DeviceInfo;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->deviceInfo:Lcom/scanflow/datacapture/model/DeviceInfo;

    return-void
.end method

.method public final setResult(Lcom/scanflow/datacapture/model/subscription/Result;)V
    .locals 0

    .line 0
    iput-object p1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->result:Lcom/scanflow/datacapture/model/subscription/Result;

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    .line 0
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, "SubscriptionResponse(message="

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->message:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", result="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->result:Lcom/scanflow/datacapture/model/subscription/Result;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", status="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->status:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v1, ", deviceInfo="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->deviceInfo:Lcom/scanflow/datacapture/model/DeviceInfo;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v1, ", apikey="

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/scanflow/datacapture/model/subscription/SubscriptionResponse;->apikey:Ljava/lang/String;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 v1, 0x29

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
